using Catalog.App.Abstractions;
using Catalog.App.Dtos;
using Catalog.Domain.Abstractions;
using Catalog.Domain.Entities;
using MediatR;

namespace Catalog.App.UseCases.Product;

public record RemoveProductCommand(int Id) : IRequest<Result<int>>;

public class RemoveProductCommandHandler(
    IRepository<ProductEntity> productRepository, 
    IUnitOfWork unitOfWork)
    : IRequestHandler<RemoveProductCommand, Result<int>>
{
    public async Task<Result<int>> Handle(RemoveProductCommand command, CancellationToken cancellationToken)
    {
        var product = await productRepository.Get(command.Id);
        await productRepository.Delete(product);
        return new Result<int>
        {
            Value = await unitOfWork.Save(cancellationToken)
        };
    }
}