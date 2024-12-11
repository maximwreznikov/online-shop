using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductDetailsController(IMediator mediator) : ControllerBase
{
    [HttpGet("{productId:int}")]
    public async Task<ActionResult<object>> GetDetails([FromRoute] int productId)
    {
        return Ok(new
        {
            ProductId = productId,
            Liked = 21,
            Brend = "Samsung",
            Rating = 8.9,
            Year = 2023
        });
    }
}
