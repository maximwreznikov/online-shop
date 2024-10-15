using Cart.Core.Abstractions.Outbound;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Cart.DAL;

public static class Bootstrap
{
    public static void AddPersistence(this IServiceCollection serviceCollection, IConfigurationManager configurationManager)
    {
        serviceCollection.Configure<LiteDbOptions>(configurationManager.GetSection(nameof(LiteDbOptions)));
        
        serviceCollection.AddSingleton<ILiteDbContext, LiteDbContext>();
        
        serviceCollection.AddScoped<ICartRepository, CartRepository>();
    }
}