using Catalog.App.Abstractions;
using Catalog.App.Dtos;
using Catalog.App.Specifications;
using Catalog.App.UseCases.Product.Dtos;
using Catalog.Domain.Abstractions;
using Catalog.Domain.Entities;
using MediatR;

namespace Catalog.App.UseCases.Product;

public record UpdateProductCommand(UpdateProductRequest Product) : IRequest<ProductResponse>;

public class UpdateProductCommandHandler(
    IRepository<ProductEntity> productRepository,
    IRepository<CategoryEntity> categoryRepository,
    IUnitOfWork unitOfWork
    )
    : IRequestHandler<UpdateProductCommand, ProductResponse>
{
    public async Task<ProductResponse> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var newProduct = request.Product;
        var product = await productRepository.Get(newProduct.Id);

        product.Name = newProduct.Name;
        product.Description = newProduct.Description;
        product.Image = newProduct.Image;
        product.Price = newProduct.Price;
        product.Amount = newProduct.Amount;

        var category = await categoryRepository.FindSingle(
            new ByNameFilter<CategoryEntity>(newProduct.Category));

        product.CategoryId = category.Id;

        await productRepository.Update(product);
        await unitOfWork.Save(cancellationToken);

        return new ProductResponse(product);
    }
}
