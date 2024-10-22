using Cart.Core.Abstractions.Inbound;
using Cart.Core.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Cart.Core;

public static class Bootstrap
{
        public static void AddCore(this IServiceCollection services, IConfigurationManager configurationManager)
        {
                services.AddScoped<ICartService, CartService>();
        }
}