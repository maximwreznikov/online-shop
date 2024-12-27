using System.Security.Claims;

namespace Catalog.Api.GraphQL;

public class GraphQLUserContext : Dictionary<string, object>
{
    public ClaimsPrincipal? User { get; set; }
}
