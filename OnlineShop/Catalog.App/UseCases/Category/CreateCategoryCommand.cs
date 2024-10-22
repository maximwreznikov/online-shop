using Catalog.App.Abstractions;
using Catalog.App.Dtos;
using Catalog.App.Specifications;
using Catalog.App.UseCases.Category.Dtos;
using Catalog.App.UseCases.Product;
using Catalog.Domain.Abstractions;
using Catalog.Domain.Entities;
using MediatR;

namespace Catalog.App.UseCases.Category;

public record CreateCategoryCommand(CategoryRequest Category) : IRequest<CategoryResponse>;

public class CreateCategoryCommandHandler(
    IRepository<CategoryEntity> categoryRepository, 
    IUnitOfWork unitOfWork)
    : IRequestHandler<CreateCategoryCommand, CategoryResponse>
{
    public async Task<CategoryResponse> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var newProduct = request.Category;
        var newEntity = new CategoryEntity
        {
            Name = newProduct.Name,
            Image = newProduct.Image
        };

        if (!string.IsNullOrEmpty(newEntity.ParentCategory))
        {
            var parentCategory = await categoryRepository.FindSingle(
                new ByNameFilter<CategoryEntity>(newEntity.ParentCategory));

            newEntity.ParentCategoryId = parentCategory.Id;
        }
        
        await categoryRepository.Create(newEntity);
        await unitOfWork.Save(cancellationToken);
        
        return new CategoryResponse
        {
            Id = newEntity.Id,
            Name = newEntity.Name,
            ParentCategoryId = newEntity.ParentCategoryId,
            ParentCategory = newEntity.ParentCategory
        };
    }
}