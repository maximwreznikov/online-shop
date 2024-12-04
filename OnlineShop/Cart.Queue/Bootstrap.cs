using Cart.Contracts.Settings;
using Cart.Queue.Consumers;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Cart.Queue;

public static class Bootstrap
{
    public static void AddMessageQueue(this IServiceCollection services, IConfigurationManager configurationManager)
    {
        var settingsSection = configurationManager.GetSection(nameof(RabbitSettings));
        services.Configure<RabbitSettings>(settingsSection);

        var settings = new RabbitSettings();
        settingsSection.Bind(settings);

        services.AddMassTransit(x =>
        {
            x.AddConsumer<AddToCartConsumer>();

            x.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host(settings.Host, "/", h =>
                {
                    h.Username(settings.Username);
                    h.Password(settings.Password);
                });

                cfg.ConfigureEndpoints(context);
            });
        });
    }
}
