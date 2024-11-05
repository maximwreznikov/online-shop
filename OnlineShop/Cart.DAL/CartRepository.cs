using Cart.Core.Abstractions.Outbound;
using Cart.Core.Entities;

namespace Cart.DAL;

public class CartRepository : ICartRepository
{
    private readonly ILiteDbContext _liteDbContext;
    
    public CartRepository(ILiteDbContext liteDbContext)
    {
        _liteDbContext = liteDbContext;
    }
    
    public CartEntity? Get(Guid id)
    {
        return _liteDbContext.Database.GetCollection<CartEntity>().FindOne(x => x.Id == id);
    }

    public CartEntity Update(CartEntity entity)
    {
        _liteDbContext.Database.GetCollection<CartEntity>().Upsert(entity);
        return entity;
    }
}