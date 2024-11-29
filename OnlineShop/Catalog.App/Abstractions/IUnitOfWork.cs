namespace Catalog.App.Abstractions;

public interface IUnitOfWork
{
    Task<int> Save(CancellationToken cancellationToken);
}
