using Catalog.App.Dtos;
using MediatR;

namespace Catalog.App.UseCases.Product;

public record UpdateProductCommand(int Id) : IRequest<Result<int>>;

public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Result<int>>
{
    public Task<Result<int>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}