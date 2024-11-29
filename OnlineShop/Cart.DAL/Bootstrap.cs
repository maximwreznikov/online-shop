using Cart.Core.Abstractions.Outbound;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Cart.DAL;

public static class Bootstrap
{
    public static void AddPersistence(this IServiceCollection services, IConfigurationManager configurationManager)
    {
        services.Configure<LiteDbOptions>(configurationManager.GetSection(nameof(LiteDbOptions)));

        services.AddSingleton<ILiteDbContext, LiteDbContext>();

        services.AddScoped<ICartRepository, CartRepository>();
    }
}
