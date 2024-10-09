namespace Cart.Core.Abstractions.Inbound;

public interface ICartService
{
    Task<Entities.CartEntity> Get(Guid cartId);
    
    Task<Entities.CartEntity> AddItem(Guid cartId, int itemId, int amount);
    
    Task<Entities.CartEntity> RemoveItem(Guid cartId, int itemId, int amount);
}