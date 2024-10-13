namespace Catalog.Domain.Abstractions;

public interface ISpecification<out T>
{
    IQueryable<T> Query();
}