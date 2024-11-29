using Cart.Contracts;
using Catalog.Api.Dtos;
using Catalog.App.UseCases.Product;
using MassTransit;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CartController(IMediator mediator, IBus bus) : ControllerBase
{
    [HttpPost("add")]
    public async Task<ActionResult> Add([FromBody] AddToCartDto item, CancellationToken cancellationToken)
    {
        var product = await mediator.Send(new GetProductQuery(item.ProductId), cancellationToken);

        if (product.Amount < item.Amount)
        {
            return NotFound($"No enough product {product.Id}");
        }

        await bus.Publish(new AddToCartMessage
        {
            CartId = item.CartId,
            ProductId = item.ProductId,
            Name = product.Name,
            Image = product.Image,
            Price = product.Price,
            Quantity = item.Amount
        }, cancellationToken);

        return Ok();
    }
}
