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
    
    public Task<List<T>> Find(ISpecification<T> specification)
    {
        return specification.Query().ToListAsync();
    }
}