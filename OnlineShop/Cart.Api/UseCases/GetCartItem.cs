using Cart.Core.Abstractions.Inbound;
using Cart.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Cart.Api.UseCases;

internal static class GetCartItem
{
    public static RouteHandlerBuilder Register(IEndpointRouteBuilder routeBuilder)
    {
        return routeBuilder.MapGet("/carts/{id:guid}/{productId:int}", Execute)
            .Produces<CartEntity>()
            .WithName("Get Cart Item")
            .WithOpenApi()
            .RequireAuthorization();
    }

    private static async Task<IResult> Execute(
        [FromRoute] Guid id,
        [FromRoute] int productId,
        [FromServices] ICartService cartService)
    {
        var cartEntity = await cartService.Get(id);
        var item = cartEntity.Items.FirstOrDefault(x => x.ProductId == productId);
        return item == null ? Results.NotFound($"No {productId} in cart {id}") : Results.Ok(item);
    }
}
