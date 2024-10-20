using Catalog.App.Abstractions;
using Catalog.App.Dtos;
using Catalog.Domain.Abstractions;
using Catalog.Domain.Entities;
using MediatR;

namespace Catalog.App.UseCases.Product;

public record CreateProductCommand(ProductRequest Product) : IRequest<Result<int>>;

public class CreateProductCommandHandler(
    IRepository<ProductEntity> productRepository, 
    IUnitOfWork unitOfWork)
    : IRequestHandler<CreateProductCommand, Result<int>>
{
    public async Task<Result<int>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var newProduct = request.Product;
        var newEntity = new ProductEntity
        {
            Name = newProduct.Name,
            Description = newProduct.Description,
            Image = newProduct.Image,
            Price = newProduct.Price,
            Amount = newProduct.Amount
        };
        
        await productRepository.Create(newEntity);
        return new Result<int>
        {
            Value = await unitOfWork.Save(cancellationToken)
        };
    }
}