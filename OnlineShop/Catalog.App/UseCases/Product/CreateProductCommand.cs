using Catalog.App.Abstractions;
using Catalog.App.Dtos;
using Catalog.App.Specifications;
using Catalog.App.UseCases.Product.Dtos;
using Catalog.Domain.Abstractions;
using Catalog.Domain.Entities;
using MediatR;

namespace Catalog.App.UseCases.Product;

public record CreateProductCommand(ProductRequest Product) : IRequest<ProductResponse>;

public class CreateProductCommandHandler(
    IRepository<ProductEntity> productRepository, 
    IRepository<CategoryEntity> categoryRepository, 
    IUnitOfWork unitOfWork)
    : IRequestHandler<CreateProductCommand, ProductResponse>
{
    public async Task<ProductResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var newProduct = request.Product;
        var product = new ProductEntity
        {
            Name = newProduct.Name,
            Description = newProduct.Description,
            Image = newProduct.Image,
            Price = newProduct.Price,
            Amount = newProduct.Amount
        };

        var category = await categoryRepository.FindSingle(
            new ByNameFilter<CategoryEntity>(newProduct.Category));

        product.CategoryId = category.Id;
        
        await productRepository.Create(product);
        await unitOfWork.Save(cancellationToken);
        
        return new ProductResponse (product);
    }
}