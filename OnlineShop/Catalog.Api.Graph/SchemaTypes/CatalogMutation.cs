using Catalog.Api.Graph.SchemaTypes.Types;
using Catalog.App.UseCases.Product;
using Catalog.App.UseCases.Product.Dtos;
using Catalog.Contracts;
using GraphQL;
using GraphQL.Types;
using MediatR;

namespace Catalog.Api.Graph.SchemaTypes;

public sealed class CatalogMutation : ObjectGraphType
{
    private readonly IMediator _mediator;

    public CatalogMutation(IMediator mediator)
    {
        _mediator = mediator;
        Name = "Mutation";

        Field<ProductType>("createProduct")
            .Argument<NonNullGraphType<ProductInputType>>("product")
            .ResolveAsync(async context =>
            {
                var product = context.GetArgument<ProductDto>("product");
                return await _mediator.Send(new CreateProductCommand(new ProductRequest
                {
                    Name = product.Name,
                    Description = product.Description,
                    Image = product.Image,
                    Price = product.Price,
                    Amount = product.Amount,
                    Category = product.Category
                }));
            });
    }
}
