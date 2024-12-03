using Cart.Core.Abstractions.Inbound;
using Cart.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Cart.Api.UseCases;

internal static class GetCartV1
{
    public static RouteHandlerBuilder Register(IEndpointRouteBuilder routeBuilder)
    {
        return routeBuilder.MapGet("/carts/{id:guid}", Execute)
            .Produces<CartEntity>()
            .WithName("GetCart V1")
            .WithOpenApi()
            .RequireAuthorization();
    }

    private static async Task<IResult> Execute(
        [FromRoute] Guid id,
        [FromServices] ICartService cartService)
    {
        var cartEntity = await cartService.Get(id);
        return Results.Ok(cartEntity);
    }
}
