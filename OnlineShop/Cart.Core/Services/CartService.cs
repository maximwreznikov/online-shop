using Cart.Core.Abstractions.Inbound;
using Cart.Core.Abstractions.Outbound;
using Cart.Core.Entities;

namespace Cart.Core.Services;

public class CartService(ICartRepository cartRepository) : ICartService
{
    public Task<CartEntity> Get(Guid cartId)
    {
        return Task.FromResult(cartRepository.Get(cartId)!);
    }

    public Task<CartEntity> AddItem(Guid cartId, CartItemEntity itemEntity)
    {
        // find cart
        var cart = cartRepository.Get(cartId) ?? new CartEntity(cartId);

        // add
        if (cart.Items == null)
        {
            cart.Items = [ ];
            itemEntity.Id = 1;
        }
        else
        {
            // find last id
            var lastId = cart.Items.MaxBy(x => x.Id)?.Id ?? 0;
            itemEntity.Id = lastId + 1;
        }

        cart.Items.Add(itemEntity);
        cartRepository.Update(cart);

        return Task.FromResult(cart);
    }

    public Task<CartEntity> RemoveItem(Guid cartId, int itemId)
    {
        // find cart
        var cart = cartRepository.Get(cartId) ?? throw new KeyNotFoundException($"No cart with id {cartId}");

        // remove item
        var item = cart.Items.Find(x => x.Id == itemId);
        if (item != null)
        {
            cart.Items.Remove(item);
        }
        // update cart
        return Task.FromResult(cartRepository.Update(cart));
    }
}
