using Cart.Core.Abstractions.Inbound;
using Microsoft.AspNetCore.Mvc;

namespace Cart.Api.UseCases;

internal static class GetCartV2
{
    public static RouteHandlerBuilder Register(IEndpointRouteBuilder routeBuilder)
    {
        return routeBuilder.MapGet("/carts/{id:guid}", Execute)
            .WithName("GetCart V2")
            .WithOpenApi();
    }
    
    public static async Task<IResult> Execute(
        [FromRoute] Guid id,
        [FromServices] ICartService cartService,
        CancellationToken cancellation)
    {
        return Results.Ok();
    }
}