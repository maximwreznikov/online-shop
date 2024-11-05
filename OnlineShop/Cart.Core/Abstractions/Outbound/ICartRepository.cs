using Cart.Core.Entities;

namespace Cart.Core.Abstractions.Outbound;

public interface ICartRepository
{
    public CartEntity? Get(Guid Id);
    
    public CartEntity Update(CartEntity entity);
}