using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Catalog.DAL;

internal class CategoryContextFactory : IDesignTimeDbContextFactory<CatalogContext>
{
    public CatalogContext CreateDbContext(string[ ] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<CatalogContext>();
        optionsBuilder.UseSqlite("Data Source=sql_main.db");

        return new CatalogContext(optionsBuilder.Options);
    }

    public static void Migrate(IDbContextFactory<CatalogContext> factory)
    {
        using var context = factory.CreateDbContext();
        context.Database.Migrate();
    }
}
