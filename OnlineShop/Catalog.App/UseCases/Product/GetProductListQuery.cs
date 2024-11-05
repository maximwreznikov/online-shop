using Catalog.App.Specifications;
using Catalog.App.UseCases.Product.Dtos;
using Catalog.Domain.Abstractions;
using Catalog.Domain.Entities;
using MediatR;

namespace Catalog.App.UseCases.Product;

public record GetProductListQuery(int Skip, int Take) : IRequest<IEnumerable<ProductResponse>>;

public class GetProductListQueryHandler(IRepository<ProductEntity> productRepository)
    : IRequestHandler<GetProductListQuery, IEnumerable<ProductResponse>>
{
    public async Task<IEnumerable<ProductResponse>> Handle(GetProductListQuery request, CancellationToken cancellationToken)
    {
        var products = await productRepository.Find(request.Skip, request.Take, 
            new EmptyFilter<ProductEntity>());
        
        return products.Select(x => new ProductResponse(x));
    }
}