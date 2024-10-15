using Catalog.App.Dtos;
using Catalog.Domain.Abstractions;
using Catalog.Domain.Entities;
using MediatR;

namespace Catalog.App.UseCases.Product;

public record GetProductQuery(int Id) : IRequest<ProductResponse>;

public class CreateProductQueryHandler : IRequestHandler<GetProductQuery, ProductResponse>
{
    private readonly IRepository<ProductEntity> _productRepository;

    public CreateProductQueryHandler(IRepository<ProductEntity> productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<ProductResponse> Handle(GetProductQuery request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.Get(request.Id);
        return new ProductResponse(product.Id, product.Name, product.Description, 
            product.Image, product.Price, product.Amount, product.Category);
    }
}