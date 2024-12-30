using Microsoft.AspNetCore.Http;

namespace Catalog.Api.Graph.Infrastructure;

public class GraphQLSettings
{
    public PathString Path { get; set; } = "/api/graphql";

    public Func<HttpContext, IDictionary<string, object>>? BuildUserContext { get; set; }

    public bool EnableMetrics { get; set; }
}
