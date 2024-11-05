using Catalog.Api.Dtos;
using Catalog.App.Dtos;
using Catalog.App.UseCases.Category;
using Catalog.App.UseCases.Category.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriesController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<CategoryResponse>>> Get(int skip = 0, int take = 1000)
    {
        var categories = await mediator.Send(new GetCategoriesQuery(skip, take));
        return Ok(categories);
    }
    
    [HttpPost]
    public async Task<ActionResult<CategoryResponse>> Create([FromBody] CategoryDto newCategory)
    {
        var response = await mediator.Send(new CreateCategoryCommand(new CategoryRequest
        {
            Name = newCategory.Name,
            Image = newCategory.Image,
            ParentCategory = newCategory.ParentCategory
        }));
        return Created($"/cart/{response.Id}", response);
    }
    
    [HttpPut("id")]
    public async Task<ActionResult<CategoryResponse>> Update([FromRoute] int id, [FromBody] CategoryDto newCategory)
    {
        var response = await mediator.Send(new UpdateCategoryCommand(new UpdateCategoryRequest
        {
            Id = id,
            Name = newCategory.Name,
            Image = newCategory.Image,
            ParentCategory = newCategory.ParentCategory
        }));
        return Ok(response);
    }
    
    [HttpDelete("id")]
    public async Task<ActionResult<CategoryResponse>> Delete([FromRoute]int id)
    {
        var response = await mediator.Send(new RemoveCategoryCommand(id));
        return Ok(response);
    }
}