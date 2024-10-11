using Catalog.App.Abstractions;
using Catalog.Domain.Entities;

namespace Catalog.DAL;

internal class CategoryRepository : Repository<Category>, ICategoryRepository
{
    public CategoryRepository(CatalogContext context) : base(context)
    {
    }
}