using Cart.Contracts.Settings;
using Catalog.Api;
using Catalog.Api.Graph;
using Catalog.Api.GraphQL;
using Catalog.Api.SchemaTypes;
using Catalog.App;
using Catalog.DAL;
using GraphQL;
using GraphQL.Caching;
using GraphQL.Server.Ui.GraphiQL;
using Keycloak.AuthServices.Authentication;
using Keycloak.AuthServices.Authorization;
using Keycloak.AuthServices.Sdk;
using MassTransit;
using Microsoft.Extensions.Diagnostics.Metrics;
using Swashbuckle.AspNetCore.SwaggerUI;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApp();
builder.Services.AddPersistence(builder.Configuration);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddGraph();

var settingsSection = builder.Configuration.GetSection(nameof(RabbitSettings));
var settings = new RabbitSettings();
settingsSection.Bind(settings);

builder.Services.AddMassTransit(x =>
{
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


// init auth
builder.Services.AddKeycloakWebApiAuthentication(builder.Configuration, o =>
{
    o.RequireHttpsMetadata = false;
});

AddAuthorization(builder);

builder.Services.AddKeycloakAdminHttpClient(builder.Configuration);

builder.Services.AddSwagger();

builder.Services.AddLogging(x => x.AddConsole());

var app = builder.Build();

app.Services.Migrate();

UseSwagger(app);

app.UseGraph();

app
    .UseAuthentication()
    .UseAuthorization();

app.MapControllers();

await app.RunAsync();

void AddAuthorization(WebApplicationBuilder webApplicationBuilder)
{
    webApplicationBuilder.Services
        .AddAuthorization(o =>
            {
                o.AddPolicy(
                    PolicyConstants.ManagerPolicy,
                    b =>
                    {
                        b.RequireResourceRoles(RolesConstants.Manager);
                    }
                );
                o.AddPolicy(
                    PolicyConstants.CustomerPolicy,
                    b =>
                    {
                        b.RequireResourceRoles(RolesConstants.Customer);
                    }
                );
            }
        )
        .AddKeycloakAuthorization(webApplicationBuilder.Configuration)
        .AddAuthorizationServer(webApplicationBuilder.Configuration);
}

void UseSwagger(WebApplication webApplication)
{
    if (webApplication.Environment.IsDevelopment())
    {
        webApplication.UseSwagger()
            .UseSwaggerUI(o =>
            {
                o.SwaggerEndpoint("/swagger/v1/swagger.json", "Catalog API v1");
                o.DocExpansion(DocExpansion.List);
                o.EnableDeepLinking();

                // Enable OAuth2 authorization support in Swagger UI
                o.OAuthClientId("test_online_shop");
                o.OAuthAppName("Swagger");
            });
    }
}


