using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Catalog.App;

public static class Bootstrap
{
    public static void AddApp(this IServiceCollection services)
    {
        services.AddMediatR(config => config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
    }
}