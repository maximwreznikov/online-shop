using Catalog.App.Abstractions;

namespace Catalog.DAL;

internal class Repository<T> : IRepository<T>
{
    private readonly CatalogContext _context;
    
    public Repository(CatalogContext context)
    {
        _context = context;
    }
    
    public Task Create()
    {
        throw new NotImplementedException();
    }

    public Task<T> Get(ISpecification<T> specification)
    {
        throw new NotImplementedException();
    }

    public Task Update(T item)
    {
        throw new NotImplementedException();
    }

    public Task Delete(T item)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<T>> Find(ISpecification<T> specification)
    {
        throw new NotImplementedException();
    }
}