namespace Cart.Core.Entities;

public class CartEntity
{
    public Guid Id { get; set; }

    public List<CartItemEntity>? Items { get; set; }

    public CartEntity()
    {
        
    }

    public CartEntity(Guid id)
    {
        Id = id;
        Items = new List<CartItemEntity>();
    }
}