using Catalog.App.Abstractions;
using Catalog.App.Dtos;
using Catalog.Domain.Abstractions;
using Catalog.Domain.Entities;
using MediatR;

namespace Catalog.App.UseCases.Product;

public record UpdateProductCommand(UpdateProductRequest Product) : IRequest<Result<int>>;

public class UpdateProductCommandHandler(
    IRepository<ProductEntity> productRepository,
    IUnitOfWork unitOfWork
    )
    : IRequestHandler<UpdateProductCommand, Result<int>>
{
    public async Task<Result<int>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var newProduct = request.Product;
        var product = await productRepository.Get(newProduct.Id);

        product.Name = newProduct.Name;
        product.Description = newProduct.Description;
        product.Image = newProduct.Image;
        product.Price = newProduct.Price;
        product.Amount = newProduct.Amount;
        product.Category = newProduct.Category;
        await productRepository.Update(product);
        return new Result<int>
        {
            Value = await unitOfWork.Save(cancellationToken)
        };
    }
}