using Cart.Core.Abstractions.Inbound;
using Microsoft.AspNetCore.Mvc;

namespace Cart.Api.UseCases;

internal static class GetCartV1
{
    public static RouteHandlerBuilder Register(IEndpointRouteBuilder routeBuilder)
    {
        return routeBuilder.MapGet("/carts/{id:guid}", Execute)
            .WithName("GetCart V1")
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