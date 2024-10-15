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
        return Task.FromResult(_cartRepository.Get(cartId));
    }

    public Task<CartEntity> AddItem(Guid cartId, int itemId, int amount)
    {
        // find cart
        var cart = _cartRepository.Get(cartId);
        
        // TODO: add 
        // get product from Catalog?
        cart.Items.Add(new CartItemEntity
        {
            
        });
        
        return Task.FromResult(new CartEntity
        {
            Id = cartId
        });
    }

    public Task<CartEntity> RemoveItem(Guid cartId, int itemId, int amount)
    {
        // find cart
        var cart = _cartRepository.Get(cartId);
        // remove item
        var item = cart.Items.Find(x => x.Id == itemId);
        if (item != null)
        {
            cart.Items.Remove(item);
        }
        // update cart
        return Task.FromResult(_cartRepository.Update(cart));
    }
}