using Catalog.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace Catalog.DAL;

public static class Bootstrap
{
    public static void AddServices(IServiceCollection services)
    {
        services.AddScoped<Repository<CategoryEntity>, CategoryRepository>();
        services.AddScoped<Repository<ProductEntity>, ProductRepository>();
    }
}