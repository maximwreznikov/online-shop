using Catalog.App.Abstractions;

namespace Catalog.DAL;

internal class UnitOfWork(CatalogContext context) : IUnitOfWork
{
    public Task<int> Save(CancellationToken cancellationToken)
    {
        return context.SaveChangesAsync(cancellationToken);
    }
}