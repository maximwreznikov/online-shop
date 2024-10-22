using Catalog.App.Abstractions;
using Catalog.Domain.Abstractions;
using Catalog.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Catalog.DAL;

public static class Bootstrap
{
    public static void AddPersistence(this IServiceCollection services, IConfigurationManager configuration)
    {
        services.AddDbContextFactory<CatalogContext>(opt =>
            opt.UseSqlite(configuration.GetConnectionString(nameof(CatalogContext))));
        
        services.AddScoped<IRepository<CategoryEntity>, CategoryRepository>();
        services.AddScoped<IRepository<ProductEntity>, ProductRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        
    }
    
    public static void Migrate(this IServiceProvider services)
    {
        CategoryContextFactory.Migrate(services.GetRequiredService<IDbContextFactory<CatalogContext>>());
    }
}