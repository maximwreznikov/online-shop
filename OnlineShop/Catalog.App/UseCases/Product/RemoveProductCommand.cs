using Catalog.App.Abstractions;
using Catalog.App.Dtos;
using Catalog.Domain.Abstractions;
using Catalog.Domain.Entities;
using MediatR;

namespace Catalog.App.UseCases.Product;

public record RemoveProductCommand(int Id) : IRequest<Result<int>>;

public class RemoveProductCommandHandler : IRequestHandler<RemoveProductCommand, Result<int>>
{
    private readonly IRepository<ProductEntity> _productRepository;
    private readonly IUnitOfWork _unitOfWork;

    public RemoveProductCommandHandler(IRepository<ProductEntity> productRepository, IUnitOfWork unitOfWork)
    {
        _productRepository = productRepository;
        _unitOfWork = unitOfWork;
    }
    
    public async Task<Result<int>> Handle(RemoveProductCommand command, CancellationToken cancellationToken)
    {
        var product = await _productRepository.Get(command.Id);
        await _productRepository.Delete(product);
        return new Result<int>
        {
            Value = await _unitOfWork.Save(cancellationToken)
        };
    }
}