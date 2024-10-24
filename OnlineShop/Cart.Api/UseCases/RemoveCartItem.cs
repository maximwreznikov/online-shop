using Cart.Core.Abstractions.Inbound;
using Microsoft.AspNetCore.Mvc;

namespace Cart.Api.UseCases;

internal static class RemoveCartItem
{
    public static RouteHandlerBuilder Register(IEndpointRouteBuilder routeBuilder)
    {
        return routeBuilder.MapDelete("/carts/{id:guid}/{itemId:int}", Execute)
            .WithName("Remove item from cart")
            .WithOpenApi();
    }
    
    public static async Task<IResult> Execute(
        [FromRoute] Guid id,
        [FromRoute] int itemId,
        [FromServices] ICartService cartService,
        CancellationToken cancellation)
    {
        return Results.Ok();
    }
}