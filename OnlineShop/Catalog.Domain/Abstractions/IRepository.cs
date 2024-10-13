namespace Catalog.Domain.Abstractions;

public interface IRepository<T> where T : class, IEntity
{
    public Task Create(T item);

    public Task<T?> Get(int id);
    
    public Task Update(T item);
    
    public Task Delete(T item);
    
    public Task<List<T>> Find(ISpecification<T> specification);
}