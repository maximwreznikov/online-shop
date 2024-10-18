using Catalog.Domain.Abstractions;

namespace Catalog.App.Abstractions;

public class FilterSpecification<T> : ISpecification<T> where T: IEntity
{
    public IQueryable<T> Query(IQueryable<T> source)
    {
        return source;
    }
}