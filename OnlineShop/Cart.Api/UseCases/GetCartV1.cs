using Microsoft.AspNetCore.Mvc;

namespace Cart.Api.UseCases;

internal static class GetCartV1
{
    public static async Task<IActionResult> Execute(
        [FromRoute] Guid id,
        CancellationToken cancellation)
    {
        return (IActionResult)Results.Ok();
    }
}