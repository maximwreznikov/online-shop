using Cart.Contracts;
using Cart.Core.Abstractions.Inbound;
using Cart.Core.Entities;
using MassTransit;

namespace Cart.Api.Consumers;

public class AddToCartConsumer(ICartService cartService, ILogger<AddToCartConsumer> logger) : IConsumer<AddToCartMessage>
{
    public async Task Consume(ConsumeContext<AddToCartMessage> context)
    {
        var message = context.Message;
        logger.LogInformation("Add products to cart {CartId}: {Id} {Name} {Quantity}", message.CartId, message.ProductId, message.Name, message.Quantity);

        var newItem = new CartItemEntity
        {
            ProductId = message.ProductId,
            Name = message.Name,
            Image = message.Image,
            Price = message.Price,
            Quantity = message.Quantity
        };
        await cartService.AddItem(message.CartId, newItem);
    }
}