using Catalog.App.Abstractions;
using Catalog.App.Dtos;
using MediatR;

namespace Catalog.App.UseCases.Product;



public record GetProductQuery : IRequest<ProductResponse>
{
    public int Id { get; init; }
}

public class CreateProductQueryHandler : IRequestHandler<GetProductQuery, ProductResponse>
{
    public Task<ProductResponse> Handle(GetProductQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}