namespace Catalog.App.Abstractions;

public interface IRepository<T>
{
    public Task Create();
    
    public Task<T> Get(ISpecification<T> specification);
    
    public Task Update(T item);
    
    public Task Delete(T item);
    
    public Task<IEnumerable<T>> Find(ISpecification<T> specification);
}