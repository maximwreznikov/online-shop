namespace Cart.Core.Entities;

public class CartEntity
{
    public Guid Id { get; set; }

    public List<CartItemEntity> Items { get; set; }

    public CartEntity()
    {
        Id = Guid.NewGuid();
        Items = new List<CartItemEntity>();
    }

    public CartEntity(Guid id)
    {
        Id = id;
        Items = new List<CartItemEntity>();
    }
}
