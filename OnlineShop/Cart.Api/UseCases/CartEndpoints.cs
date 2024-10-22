using Microsoft.AspNetCore.Mvc;

namespace Cart.Api.UseCases;

public static class CartEndpoints
{
    public static void MapV1(RouteGroupBuilder group)
    {
        group.MapGet("/carts/{id}", GetCartV1.Execute)
        .WithName("GetCart V1")
        .WithOpenApi();
    
        group.MapPost("/carts/{id}", async (int id, [FromBody] object itenRequest) =>
        {
            return Results.Created($"/carts/{id}", 0);
        })
        .WithName("Add new item")
        .WithOpenApi();

        group.MapDelete("/carts/{id}/{itemId}", async (int id, int itemId) =>
        {
            return Results.NotFound();
        })
        .WithName("Remove item")
        .WithOpenApi();
    }
    
    public static void MapV2(RouteGroupBuilder group)
    {
        group.MapGet("/carts/{id}", async (int id) =>
        {
            return Results.Ok();
        })
        .WithName("GetCart V2")
        .WithOpenApi();
    
        group.MapPost("/carts/{id}", async (int id, [FromBody] object itemRequest) =>
        {
            return Results.Created($"/cart/{id}", 0);
        })
        .WithName("Add new item V2")
        .WithOpenApi();

        group.MapDelete("/carts/{id}/{itemId}", async (int id, int itemId) =>
        {
            return Results.NotFound();
        })
        .WithName("Remove item v2")
        .WithOpenApi();
    }
}