namespace Cart.Core.Entities;

public class CartEntity
{
    public Guid Id { get; set; }

    public List<CartItemEntity> Items { get; set; } = new();
}