using Catalog.Domain.Abstractions;

namespace Catalog.App.Specifications;

public class EmptyFilter<T> : ISpecification<T> where T: IEntity
{
    public IQueryable<T> Query(IQueryable<T> source)
    {
        return source;
    }
}