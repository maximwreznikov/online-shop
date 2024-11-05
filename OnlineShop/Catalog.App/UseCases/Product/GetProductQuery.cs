using Catalog.App.Dtos;
using Catalog.App.UseCases.Product.Dtos;
using Catalog.Domain.Abstractions;
using Catalog.Domain.Entities;
using MediatR;

namespace Catalog.App.UseCases.Product;

public record GetProductQuery(int Id) : IRequest<ProductResponse>;

public class GetProductQueryHandler(IRepository<ProductEntity> productRepository)
    : IRequestHandler<GetProductQuery, ProductResponse>
{
    public async Task<ProductResponse> Handle(GetProductQuery request, CancellationToken cancellationToken)
    {
        var product = await productRepository.Get(request.Id);
        
        return new ProductResponse(product);
    }
}