using Cart.Core.Entities;

namespace Cart.Api.Services;

public static class Converters
{
    public static ItemListResponse ToResponse(this CartEntity entity)
    {
        var response = new ItemListResponse();
        response.Items.AddRange(entity.Items.Select(x => x.ToData()));
        return response;
    }

    public static ItemData ToData(this CartItemEntity itemEntity)
    {
        var response = new ItemData
        {
            Id = itemEntity.Id,
            ProductId = itemEntity.ProductId,
            Name = itemEntity.Name,
            Image = itemEntity.Image,
            Price = (double)itemEntity.Price,
            Quantity = itemEntity.Quantity
        };
        return response;
    }

    public static CartItemEntity ToItemEntity(this ItemData item)
    {
        var entity = new CartItemEntity();
        entity.ProductId = item.ProductId;
        entity.Name = item.Name;
        entity.Image = item.Image;
        entity.Price = (decimal)item.Price;
        entity.Quantity = item.Quantity;
        return entity;
    }

    public static ItemResponse ToResponse(this CartItemEntity itemEntity)
    {
        var response = new ItemResponse();
        response.Data = itemEntity.ToData();
        return response;
    }
}
