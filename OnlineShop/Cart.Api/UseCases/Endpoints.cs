
using Asp.Versioning.Builder;

namespace Cart.Api.UseCases;

public static class Endpoints
{
    public static void MapV1(RouteGroupBuilder group, ApiVersionSet apiVersionSet)
    {
        AddCartItem.Register(group)
            .WithApiVersionSet(apiVersionSet)
            .MapToApiVersion(1);

        GetCartV1.Register(group)
            .WithApiVersionSet(apiVersionSet)
            .MapToApiVersion(1);

        RemoveCartItem.Register(group)
            .WithApiVersionSet(apiVersionSet)
            .MapToApiVersion(1);
    }

    public static void MapV2(RouteGroupBuilder group, ApiVersionSet apiVersionSet)
    {
        GetCartV2.Register(group)
            .WithApiVersionSet(apiVersionSet)
            .MapToApiVersion(2);
    }
}
