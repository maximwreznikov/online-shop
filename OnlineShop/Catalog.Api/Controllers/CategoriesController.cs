using Catalog.Api.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriesController : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<CategoryDto>>> Get()
    {
        return Ok(Enumerable.Empty<CategoryDto>());
    }
    
    [HttpPost]
    public async Task<ActionResult<CategoryDto>> Create([FromBody] CategoryDto newCategory)
    {
        return Created($"/cart/{0}", newCategory);
    }
    
    [HttpPut("id")]
    public async Task<ActionResult<CategoryDto>> Update(int id, [FromBody] CategoryDto newCategory)
    {
        return Ok(newCategory);
    }
    
    [HttpDelete("id")]
    public async Task<IActionResult> Delete(int id)
    {
        return NoContent();
    }
}