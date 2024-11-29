using Catalog.Domain.Abstractions;

namespace Catalog.App.Specifications;

public class ByNameFilter<T>(string name) : ISpecification<T>
    where T : INamedEntity
{
    public IQueryable<T> Query(IQueryable<T> source)
    {
        return source.Where(x => x.Name == name);
    }
}
