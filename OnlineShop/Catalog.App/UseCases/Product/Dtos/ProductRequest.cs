namespace Catalog.App.UseCases.Product.Dtos;

public class ProductRequest
{
    public string Name { get; set; } = string.Empty;

    public string? Description { get; set; }

    // Url
    public string? Image { get; set; }

    public decimal Price { get; set; }

    public uint Amount { get; set; }

    public string Category { get; set; } = null!;
}
