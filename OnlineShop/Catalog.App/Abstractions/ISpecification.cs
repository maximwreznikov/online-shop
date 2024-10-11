namespace Catalog.App.Abstractions;

public interface ISpecification<out T>
{
    IQueryable<T> Query();
}