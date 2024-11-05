using Cart.Core.Entities;

namespace Cart.Core.Abstractions.Inbound;

public interface ICartService
{
    Task<Entities.CartEntity> Get(Guid cartId);
    
    Task<Entities.CartEntity> AddItem(Guid cartId, CartItemEntity itemEntity);
    
    Task<Entities.CartEntity> RemoveItem(Guid cartId, int itemId);
}