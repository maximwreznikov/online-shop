using Catalog.Api.Graph.Infrastructure;
using Catalog.Api.Graph.SchemaTypes;
using Catalog.Api.GraphQL;
using Catalog.Api.SchemaTypes;
using GraphQL;
using GraphQL.Server.Ui.GraphiQL;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using ServiceLifetime = GraphQL.DI.ServiceLifetime;

namespace Catalog.Api.Graph;

public static class Bootstrap
{
    public static void AddGraph(this IServiceCollection services)
    {
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

        services.AddGraphQL(b => b
                .AddSchema<CatalogSchema>(ServiceLifetime.Scoped)
                .AddSystemTextJson()
                .AddErrorInfoProvider(opt => opt.ExposeExceptionDetails = true)
                .AddGraphTypes(typeof(CatalogSchema).Assembly))
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
