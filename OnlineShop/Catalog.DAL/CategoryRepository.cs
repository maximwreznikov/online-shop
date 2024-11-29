using Catalog.App.Abstractions;
using Catalog.Domain.Entities;

namespace Catalog.DAL;

internal class CategoryRepository : Repository<CategoryEntity>, ICategoryRepository
{
    public CategoryRepository(CatalogContext context) : base(context)
    {
    }
}
