using Catalog.App.Specifications;
using Catalog.App.UseCases.Product;
using Catalog.Domain.Abstractions;
using Catalog.Domain.Entities;
using NSubstitute;

namespace Catalog.App.UnitTests;

public class GetProductListTests
{
    private readonly IRepository<ProductEntity> _mockCartRepository = Substitute.For<IRepository<ProductEntity>>();

    [Test]
    public async Task GetList_ShouldReturnNonEmptyList()
    {
        // arrange
        var handler = new GetProductListQueryHandler(_mockCartRepository);
        var list = new List<ProductEntity>
        {
            new ProductEntity{ Id = 1},
            new ProductEntity{ Id = 2}
        };

        _mockCartRepository.Find(0, 100,
            Arg.Is<ISpecification<ProductEntity>>(x => x is EmptyFilter<ProductEntity>))
            .Returns(Task.FromResult(list));
        var newQuery = new GetProductListQuery(0, 100);

        // act
        var products = await handler.Handle(newQuery, CancellationToken.None);

        // assert
        Assert.That(products.Count, Is.EqualTo(2));
    }
}
