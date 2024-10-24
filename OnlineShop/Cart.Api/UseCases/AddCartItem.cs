using Cart.Api.Dtos;
using Cart.Core.Abstractions.Inbound;
using Microsoft.AspNetCore.Mvc;

namespace Cart.Api.UseCases;

internal static class AddCartItem
{
    public static RouteHandlerBuilder Register(IEndpointRouteBuilder routeBuilder)
    {
        return routeBuilder.MapPost("/carts/{id:guid}", Execute)
            .WithOpenApi();
    }
    
    public static async Task<IResult> Execute(
        [FromRoute] Guid id,
        [FromBody] CartItemDto itemDto,
        [FromServices] ICartService cartService,
        CancellationToken cancellation)
    {
        return Results.Ok();
    }
}