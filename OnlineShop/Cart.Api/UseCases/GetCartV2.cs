using Cart.Core.Abstractions.Inbound;
using Cart.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Cart.Api.UseCases;

internal static class GetCartV2
{
    public static RouteHandlerBuilder Register(IEndpointRouteBuilder routeBuilder)
    {
        return routeBuilder.MapGet("/carts/{id:guid}", Execute)
            .Produces<IEnumerable<CartItemEntity>>()
            .WithName("GetCart V2")
            .WithOpenApi();
    }

    private static async Task<IResult> Execute(
        [FromRoute] Guid id,
        [FromServices] ICartService cartService,
        CancellationToken cancellation)
    {
        var cartEntity = await cartService.Get(id);
        return Results.Ok(cartEntity.Items);
    }
}