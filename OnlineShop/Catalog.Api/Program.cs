using Catalog.Api;
using Catalog.App;
using Catalog.DAL;
using Keycloak.AuthServices.Authentication;
using Keycloak.AuthServices.Authorization;
using Keycloak.AuthServices.Sdk;
using MassTransit;
using Swashbuckle.AspNetCore.SwaggerUI;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApp();
builder.Services.AddPersistence(builder.Configuration);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddMassTransit(x =>
{
    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host("localhost", "/", h =>
        {
            h.Username("test");
            h.Password("test");
        });

        cfg.ConfigureEndpoints(context);
    });
});

builder.Services.AddKeycloakWebApiAuthentication(builder.Configuration, o =>
{
    o.RequireHttpsMetadata = false;
});

builder.Services
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
    .AddKeycloakAuthorization(builder.Configuration)
    .AddAuthorizationServer(builder.Configuration);

builder.Services.AddKeycloakAdminHttpClient(builder.Configuration);

builder.Services.AddSwagger();

var app = builder.Build();

app.Services.Migrate();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger()
        .UseSwaggerUI(o =>
        {
            o.SwaggerEndpoint("/swagger/v1/swagger.json", "Catalog API v1");
            o.DocExpansion(DocExpansion.List);
            o.EnableDeepLinking();

            // Enable OAuth2 authorization support in Swagger UI
            o.OAuthClientId("test_online_shop");
            o.OAuthAppName("Swagger");
        })
        .UseAuthentication()
        .UseAuthorization();
}

app.UseHttpsRedirection();

app.MapControllers();


app.Run();

