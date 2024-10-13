using Catalog.App.Abstractions;
using Catalog.App.Dtos;
using MediatR;

namespace Catalog.App.UseCases.Product;

public record CreateProductCommand(int Id) : IRequest<Result<int>>;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Result<int>>
{
    public Task<Result<int>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}