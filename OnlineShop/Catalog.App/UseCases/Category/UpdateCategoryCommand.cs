using Catalog.App.Abstractions;
using Catalog.App.Dtos;
using Catalog.Domain.Abstractions;
using Catalog.Domain.Entities;
using MediatR;

namespace Catalog.App.UseCases.Category;

public record UpdateCategoryCommand(UpdateProductRequest Category) : IRequest<Result<int>>;

public class UpdateProductCommandHandler(
    IRepository<CategoryEntity> categoryRepository,
    IUnitOfWork unitOfWork
    )
    : IRequestHandler<UpdateCategoryCommand, Result<int>>
{
    public async Task<Result<int>> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        var newCategory = request.Category;
        var category = await categoryRepository.Get(newCategory.Id);

        category.Name = newCategory.Name;
        category.Image = newCategory.Image;
        await categoryRepository.Update(category);
        return new Result<int>
        {
            Value = await unitOfWork.Save(cancellationToken)
        };
    }
}