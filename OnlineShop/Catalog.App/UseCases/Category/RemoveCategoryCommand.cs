using Catalog.App.Abstractions;
using Catalog.App.Dtos;
using Catalog.App.UseCases.Category.Dtos;
using Catalog.Domain.Abstractions;
using Catalog.Domain.Entities;
using MediatR;

namespace Catalog.App.UseCases.Category;

public record RemoveCategoryCommand(int Id) : IRequest<CategoryResponse>;

public class RemoveCategoryCommandHandler(
    IRepository<CategoryEntity> categoryRepository,
    IUnitOfWork unitOfWork)
    : IRequestHandler<RemoveCategoryCommand, CategoryResponse>
{
    public async Task<CategoryResponse> Handle(RemoveCategoryCommand command, CancellationToken cancellationToken)
    {
        var category = await categoryRepository.Get(command.Id);
        await categoryRepository.Delete(category);
        await unitOfWork.Save(cancellationToken);

        return new CategoryResponse
        {
            Id = category.Id,
            Name = category.Name,
            ParentCategory = category.ParentCategory,
            ParentCategoryId = category.ParentCategoryId
        };
    }
}
