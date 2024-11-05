namespace Cart.Core.Entities;

public class CartItemEntity
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;
    
    // URL
    public string? Image { get; set; }
    
    public decimal Price { get; set; }
    
    public int Quantity { get; set; }
}