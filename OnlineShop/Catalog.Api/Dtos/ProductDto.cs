namespace Catalog.Api.Dtos;

public record ProductDto
{
    public string Name { get; init; } = string.Empty;

    public string? Description { get; init; }

    // Url
    public string? Image { get; init; }

    public decimal Price { get; init; }

    public uint Amount { get; init; }

    public string Category { get; init; } = null!;
};
