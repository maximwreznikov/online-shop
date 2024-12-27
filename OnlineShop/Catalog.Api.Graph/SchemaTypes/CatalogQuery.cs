using Catalog.Api.Graph.SchemaTypes.Types;
using Catalog.Api.SchemaTypes.Types;
using Catalog.App.UseCases.Category;
using Catalog.App.UseCases.Category.Dtos;
using Catalog.App.UseCases.Product;
using Catalog.App.UseCases.Product.Dtos;
using GraphQL;
using GraphQL.Types;
using MediatR;

namespace Catalog.Api.Graph.SchemaTypes;

public sealed class CatalogQuery : ObjectGraphType
{
    private readonly IMediator _mediator;

    public CatalogQuery(IMediator mediator)
    {
        _mediator = mediator;
        Name = "Query";

        Field<ListGraphType<ProductType>>("products")
            .Argument<int>("skip")
            .Argument<int>("take")
            .ResolveAsync(async ctx => await GetProducts(ctx));

        Field<ListGraphType<CategoryType>>("categories")
            .Argument<int>("skip")
            .Argument<int>("take")
            .ResolveAsync(async ctx => await GetCategories(ctx));
    }

    private async Task<IEnumerable<ProductResponse>> GetProducts(IResolveFieldContext ctx)
    {
        int skip = ctx.GetArgument<int>("skip");
        int take = ctx.GetArgument<int>("take");
        return await _mediator.Send(new GetProductListQuery(skip, take), ctx.CancellationToken);
    }

    private async Task<IEnumerable<CategoryResponse>> GetCategories(IResolveFieldContext ctx)
    {
        int skip = ctx.GetArgument<int>("skip");
        int take = ctx.GetArgument<int>("take");
        return await _mediator.Send(new GetCategoriesQuery(skip, take), ctx.CancellationToken);
    }
}
