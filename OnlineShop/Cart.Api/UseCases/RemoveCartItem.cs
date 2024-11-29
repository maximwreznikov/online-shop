using Cart.Core.Abstractions.Inbound;
using Cart.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Cart.Api.UseCases;

internal static class RemoveCartItem
{
    public static RouteHandlerBuilder Register(IEndpointRouteBuilder routeBuilder)
    {
        return routeBuilder.MapDelete("/carts/{id:guid}/{itemId:int}", Execute)
            .Produces<CartEntity>()
            .WithName("Remove item from cart")
            .WithOpenApi();
    }

    private static async Task<IResult> Execute(
        [FromRoute] Guid id,
        [FromRoute] int itemId,
        [FromServices] ICartService cartService,
        CancellationToken cancellation)
    {
        var entity = await cartService.RemoveItem(id, itemId);
        return Results.Ok(entity);
    }
}
