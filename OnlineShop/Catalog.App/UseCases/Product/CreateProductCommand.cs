using Catalog.App.Abstractions;
using Catalog.App.Dtos;
using MediatR;

namespace Catalog.App.UseCases.Product;



public record CreateProductCommand : IRequest<Result<int>>
{
    public int Id { get; init; }
}

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Result<int>>
{
    public Task<Result<int>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}