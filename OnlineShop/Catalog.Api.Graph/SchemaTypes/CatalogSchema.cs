using GraphQL.Instrumentation;
using GraphQL.Types;
using Microsoft.Extensions.DependencyInjection;

namespace Catalog.Api.Graph.SchemaTypes;

public class CatalogSchema : Schema
{
    public CatalogSchema(IServiceProvider provider)
        : base(provider)
    {
        Query = provider.GetService<CatalogQuery>() ?? throw new InvalidOperationException();
        Mutation = provider.GetService<CatalogMutation>() ?? throw new InvalidOperationException();

        FieldMiddleware.Use(new InstrumentFieldsMiddleware());
    }
}
