using Catalog.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Catalog.DAL;

internal class CatalogContext : DbContext
{
    public DbSet<CategoryEntity> Categories { get; set; }
    
    public DbSet<ProductEntity> Products { get; set; }
}