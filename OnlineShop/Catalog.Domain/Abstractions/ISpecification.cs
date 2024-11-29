namespace Catalog.Domain.Abstractions;

public interface ISpecification<T>
{
    IQueryable<T> Query(IQueryable<T> source);
}
