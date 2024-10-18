using Catalog.App.Abstractions;
using Catalog.App.Dtos;
using Catalog.App.UseCases.Product;
using Catalog.Domain.Abstractions;
using Catalog.Domain.Entities;
using MediatR;

namespace Catalog.App.UseCases.Category;

public record CreateCategoryCommand(ProductRequest Product) : IRequest<Result<int>>;

public class CreateCategoryCommandHandler(
    IRepository<CategoryEntity> categoryRepository, 
    IUnitOfWork unitOfWork)
    : IRequestHandler<CreateCategoryCommand, Result<int>>
{
    public async Task<Result<int>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var newProduct = request.Product;
        var newEntity = new CategoryEntity
        {
            Name = newProduct.Name,
            Image = newProduct.Image,
        };
        
        await categoryRepository.Create(newEntity);
        return new Result<int>
        {
            Value = await unitOfWork.Save(cancellationToken)
        };
    }
}