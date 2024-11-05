using Catalog.Domain.Entities;

namespace Catalog.App.UseCases.Product.Dtos;

public record ProductResponse(
    int Id,
    string Name,
    string? Description,
    string? Image,
    decimal Price,
    uint Amount,
    int? CategoryId,
    string? Category
)
{
    public ProductResponse(ProductEntity entity) : this(
        entity.Id, 
        entity.Name, 
        entity.Description, 
        entity.Image, 
        entity.Price, 
        entity.Amount, 
        entity.Category?.Id,
        entity.Category?.Name)
    {
    }
};
    