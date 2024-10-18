using Catalog.App.Abstractions;
using Catalog.App.Dtos;
using Catalog.Domain.Abstractions;
using Catalog.Domain.Entities;
using MediatR;

namespace Catalog.App.UseCases.Category;

public record RemoveCategoryCommand(int Id) : IRequest<Result<int>>;

public class RemoveProductCommandHandler(
    IRepository<CategoryEntity> categoryRepository, 
    IUnitOfWork unitOfWork)
    : IRequestHandler<RemoveCategoryCommand, Result<int>>
{
    public async Task<Result<int>> Handle(RemoveCategoryCommand command, CancellationToken cancellationToken)
    {
        var category = await categoryRepository.Get(command.Id);
        await categoryRepository.Delete(category);
        return new Result<int>
        {
            Value = await unitOfWork.Save(cancellationToken)
        };
    }
}