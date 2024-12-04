using Cart.Core.Abstractions.Outbound;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Cart.DAL;

public static class Bootstrap
{
    public static void AddPersistence(this IServiceCollection services, IConfigurationManager configurationManager)
    {
        var litedbSection = configurationManager.GetSection(nameof(LiteDbOptions));
        services.Configure<LiteDbOptions>(litedbSection);

        services.AddSingleton<ILiteDbContext, LiteDbContext>();

        services.AddScoped<ICartRepository, CartRepository>();
    }
}
