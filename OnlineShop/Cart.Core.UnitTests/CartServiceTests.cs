using Cart.Core.Abstractions.Outbound;
using Cart.Core.Entities;
using Cart.Core.Services;
using NSubstitute;

namespace Cart.Core.UnitTests;

public class CartServiceTests
{
    private readonly ICartRepository _mockCartRepository = Substitute.For<ICartRepository>();

    [Test]
    public async Task AddItem_ShouldCreateItemInCart()
    {
        // arrange
        var testService = new CartService(_mockCartRepository);
        var testCartId = Guid.NewGuid();
        var testItemId = 5;
        var cartEntity = new CartEntity
        {
            Id = testCartId,
            Items = [new CartItemEntity{Id = testItemId}]
        };
        _mockCartRepository.Get(testCartId).Returns(cartEntity);
        var newCartItemEntity = new CartItemEntity
        {
            Id = testItemId,
            Name = "T",
            Image = "./test.jpeg",
            Price = 1.1m,
            Quantity = 5
        };

        // act
        var cart = await testService.AddItem(testCartId, newCartItemEntity);

        // assert
        Assert.That(cart.Id, Is.EqualTo(testCartId));
        Assert.That(cart.Items.Count, Is.EqualTo(1));
    }
}