namespace Cart.Contracts;

public record AddToCartMessage
{
    public Guid CartId { get; init; }

    public int ProductId { get; init; }

    public string Name { get; init; } = string.Empty;

    public string? Image { get; init; }

    public decimal Price { get; init; }

    public int Quantity { get; init; }
}
