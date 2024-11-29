using Catalog.App.Abstractions;
using Catalog.Domain.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Catalog.DAL;

internal class Repository<T>(CatalogContext context) : IRepository<T> where T : class, IEntity
{
    public async Task Create(T item)
    {
        context.Set<T>().Add(item);
    }

    public Task<T?> Get(int id)
    {
        return context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task Update(T item)
    {
        context.Set<T>().Update(item);
    }

    public async Task Delete(T item)
    {
        context.Set<T>().Remove(item);
    }

    public Task<List<T>> Find(int skip, int take, ISpecification<T> specification)
    {
        return specification.Query(context.Set<T>())
            .Skip(skip)
            .Take(take)
            .ToListAsync();
    }

    public Task<T?> FindSingle(ISpecification<T> specification)
    {
        return specification.Query(context.Set<T>()).SingleOrDefaultAsync();
    }
}
