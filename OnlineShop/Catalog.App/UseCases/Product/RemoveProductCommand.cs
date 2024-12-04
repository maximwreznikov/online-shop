using Catalog.App.Abstractions;
using Catalog.App.Dtos;
using Catalog.App.Exceptions;
using Catalog.App.UseCases.Product.Dtos;
using Catalog.Domain.Abstractions;
using Catalog.Domain.Entities;
using MediatR;

namespace Catalog.App.UseCases.Product;

public record RemoveProductCommand(int Id) : IRequest<ProductResponse>;

public class RemoveProductCommandHandler(
    IRepository<ProductEntity> productRepository,
    IUnitOfWork unitOfWork)
    : IRequestHandler<RemoveProductCommand, ProductResponse>
{
    public async Task<ProductResponse> Handle(RemoveProductCommand command, CancellationToken cancellationToken)
    {
        var product = await productRepository.Get(command.Id) ?? throw new NotFoundEntity(nameof(ProductEntity));
        await productRepository.Delete(product);
        await unitOfWork.Save(cancellationToken);
        return new ProductResponse(product);
    }
}
