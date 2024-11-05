using Catalog.Domain.Entities;

namespace Catalog.DAL;

internal class ProductRepository(CatalogContext context) : Repository<ProductEntity>(context)
{
}