using System.Security.Claims;

namespace Catalog.Api.Graph.Infrastructure;

public class GraphQLUserContext : Dictionary<string, object>
{
    public ClaimsPrincipal? User { get; set; }
}
