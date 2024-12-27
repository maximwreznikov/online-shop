using System.ComponentModel.DataAnnotations;

namespace Catalog.Contracts;

public record ProductDto
{
    [Required]
    public string Name { get; init; } = string.Empty;

    public string? Description { get; init; }

    // Url
    public string? Image { get; init; }

    [Required]
    public decimal Price { get; init; }

    [Required]
    public uint Amount { get; init; }

    [Required]
    public string Category { get; init; } = null!;
};
