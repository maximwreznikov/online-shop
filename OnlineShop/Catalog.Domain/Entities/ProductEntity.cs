using Catalog.Domain.Abstractions;

namespace Catalog.Domain.Entities;

public class ProductEntity : IEntity, INamedEntity
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string? Description { get; set; }

    // Url
    public string? Image { get; set; }

    public decimal Price { get; set; }

    public uint Amount { get; set; }


    public int? CategoryId { get; set; }

    public CategoryEntity? Category { get; set; } = null!;
}
