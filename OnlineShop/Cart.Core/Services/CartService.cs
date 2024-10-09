using Cart.Core.Abstractions.Inbound;
using Cart.Core.Abstractions.Outbound;
using Cart.Core.Entities;

namespace Cart.Core.Services;

public class CartService : ICartService
{
    private readonly ICartRepository _cartRepository;
    
    public CartService(ICartRepository cartRepository)
    {
        _cartRepository = cartRepository;
    }

    public Task<CartEntity> Get(Guid cartId)
    {
        throw new NotImplementedException();
    }

    public Task<CartEntity> AddItem(Guid cartId, int itemId, int amount)
    {
        // TODO: find cart
        
        // TODO: add 
        
        // TODO: get product from Catalog?
        
        return Task.FromResult(new CartEntity
        {
            Id = cartId
        });
    }

    public Task<CartEntity> RemoveItem(Guid cartId, int itemId, int amount)
    {
        throw new NotImplementedException();
    }
}