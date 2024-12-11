using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Ocelot.Cache.CacheManager;

namespace Gateway.Api;

public static class Program
{
    public static void Main(string[ ] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Configuration.AddJsonFile("ocelot.json", false, true);

        builder.Services.AddOcelot()
            .AddCacheManager(x => x.WithDictionaryHandle())
            .AddSingletonDefinedAggregator<CombineProductDetailsAggregator>();

        var app = builder.Build();

        app.UseOcelot();

        app.Run();
    }
}
