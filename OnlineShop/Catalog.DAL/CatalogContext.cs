using Catalog.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Catalog.DAL;

internal class CatalogContext : DbContext
{
    public DbSet<Category> Categories { get; set; }
    
    public DbSet<Product> Products { get; set; }
}