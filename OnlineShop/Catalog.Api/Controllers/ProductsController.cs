using Catalog.Api.Dtos;
using Catalog.App.Dtos;
using Catalog.App.UseCases.Category;
using Catalog.App.UseCases.Category.Dtos;
using Catalog.App.UseCases.Product;
using Catalog.App.UseCases.Product.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductResponse>>> Get(int skip = 0, int take = 1000)
    {
        var products = await mediator.Send(new GetProductListQuery(skip, take));
        return Ok(products);
    }
    
    [HttpPost]
    public async Task<ActionResult<CategoryResponse>> Create([FromBody] ProductDto newProduct)
    {
        var response = await mediator.Send(new CreateProductCommand(new ProductRequest
        {
            Name = newProduct.Name,
            Description = newProduct.Description,
            Image = newProduct.Image,
            Price = newProduct.Price,
            Amount = newProduct.Amount,
            Category = newProduct.Category
        }));
        return Created($"/cart/{response.Id}", response);
    }
    
    [HttpPut("id")]
    public async Task<ActionResult<ProductResponse>> Update([FromRoute] int id, [FromBody] ProductDto newProduct)
    {
        var response = await mediator.Send(new UpdateProductCommand(new UpdateProductRequest
        {
            Id = id,
            Name = newProduct.Name,
            Description = newProduct.Description,
            Image = newProduct.Image,
            Price = newProduct.Price,
            Amount = newProduct.Amount,
            Category = newProduct.Category
        }));
        return Ok(response);
    }
    
    [HttpDelete("id")]
    public async Task<ActionResult<ProductResponse>> Delete([FromRoute]int id)
    {
        var response = await mediator.Send(new RemoveProductCommand(id));
        return Ok(response);
    }
}