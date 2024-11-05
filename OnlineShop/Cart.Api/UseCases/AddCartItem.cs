using Cart.Api.Dtos;
using Cart.Core.Abstractions.Inbound;
using Cart.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Cart.Api.UseCases;

internal static class AddCartItem
{
    public static RouteHandlerBuilder Register(IEndpointRouteBuilder routeBuilder)
    {
        return routeBuilder.MapPost("/carts/{id:guid}", Execute)
            .Produces<CartEntity>()
            .WithName("Add item to cart")
            .WithOpenApi();
    }

    private static async Task<IResult> Execute(
        [FromRoute] Guid id,
        [FromBody] CartItemDto itemDto,
        [FromServices] ICartService cartService,
        CancellationToken cancellation)
    {
        var newItem = new CartItemEntity
        {
            Image = itemDto.Image,
            Price = itemDto.Price,
            Quantity = itemDto.Quantity,
            Name = itemDto.Name
        };
        var entity = await cartService.AddItem(id, newItem);
        return Results.Ok(entity);
    }
}