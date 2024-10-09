using Cart.Core.Abstractions.Outbound;
using Cart.Core.Services;
using NSubstitute;

namespace Cart.Core.UnitTests;

public class CartServiceTests
{
    private readonly ICartRepository _mockCartRepository = Substitute.For<ICartRepository>();

    [Test]
    public async Task AddItem_ShouldCreateItemInCart()
    {
        var testService = new CartService(_mockCartRepository);
        var testCartId = Guid.NewGuid();
        var testItemId = 5;
        var testAmount = 5;

        var cart = await testService.AddItem(testCartId, testItemId, testAmount);

        Assert.That(cart.Id, Is.EqualTo(testCartId));
        
        Assert.Pass();
    }
}