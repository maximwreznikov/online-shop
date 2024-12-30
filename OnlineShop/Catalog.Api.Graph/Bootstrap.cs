using Catalog.Api.Graph.Infrastructure;
using Catalog.Api.Graph.SchemaTypes;
using GraphQL;
using GraphQL.Server.Transports.AspNetCore;
using GraphQL.Server.Ui.GraphiQL;
using GraphQL.Validation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using ServiceLifetime = GraphQL.DI.ServiceLifetime;

namespace Catalog.Api.Graph;

public static class Bootstrap
{
    public static void AddGraph(this IServiceCollection services)
    {
        services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

        services.AddSingleton(new GraphQLSettings
        {
            Path = "/api/graphql",
            BuildUserContext = ctx => new GraphQLUserContext
            {
                User = ctx.User
            },
            EnableMetrics = true
        });

        services.AddSingleton<GraphQLMiddleware>();

        // services.AddTransient<IValidationRule, AuthorizationValidationRule>();

        services.AddGraphQL(b => b
                .AddSchema<CatalogSchema>(ServiceLifetime.Scoped)
                .AddSystemTextJson()
                .AddErrorInfoProvider(opt => opt.ExposeExceptionDetails = true)
                .AddGraphTypes(typeof(CatalogSchema).Assembly)
                .AddAuthorizationRule())
            .AddMemoryCache();
    }

    public static void UseGraph(this IApplicationBuilder app)
    {
        var graphQlOptions = new GraphiQLOptions
        {
            Headers = new Dictionary<string, string>
            {
                {"Authorization", "Bearer <your-jwt-token>"}
            },
            GraphQLEndPoint = "/api/graphql",
        };
        app.UseGraphQLGraphiQL(options:graphQlOptions);

        app.UseMiddleware<GraphQLMiddleware>();

        app.UseHttpsRedirection();
    }
}
