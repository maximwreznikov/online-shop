using Catalog.App.Abstractions;
using Catalog.App.Dtos;
using Catalog.App.Specifications;
using Catalog.App.UseCases.Category.Dtos;
using Catalog.Domain.Abstractions;
using Catalog.Domain.Entities;
using MediatR;

namespace Catalog.App.UseCases.Category;

public record UpdateCategoryCommand(UpdateCategoryRequest Category) : IRequest<CategoryResponse>;

public class UpdateCategoryCommandHandler(
    IRepository<CategoryEntity> categoryRepository,
    IUnitOfWork unitOfWork
    )
    : IRequestHandler<UpdateCategoryCommand, CategoryResponse>
{
    public async Task<CategoryResponse> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        var newCategory = request.Category;
        var category = await categoryRepository.Get(newCategory.Id);

        category.Name = newCategory.Name;
        category.Image = newCategory.Image;
        
        if (!string.IsNullOrEmpty(newCategory.ParentCategory))
        {
            var parentCategory = await categoryRepository.FindSingle(
                new ByNameFilter<CategoryEntity>(newCategory.ParentCategory));

            category.ParentCategoryId = parentCategory.Id;
            category.ParentCategory = parentCategory.Name;
        }
        else
        {
            category.ParentCategoryId = null;
            category.ParentCategory = null;
        }
        
        await categoryRepository.Update(category);
        await unitOfWork.Save(cancellationToken);
        return new CategoryResponse
        {
            Id = category.Id,
            Name = category.Name,
            Image = category.Image,
            ParentCategoryId = category.ParentCategoryId,
            ParentCategory = category.ParentCategory
        };
    }
}