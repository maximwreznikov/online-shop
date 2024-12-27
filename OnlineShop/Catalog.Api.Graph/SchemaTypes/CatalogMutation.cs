using Catalog.Api.Graph.SchemaTypes.Types;
using Catalog.Api.SchemaTypes.Types;
using Catalog.App.UseCases.Category;
using Catalog.App.UseCases.Category.Dtos;
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
            .ResolveAsync(CreateProduct());

        Field<CategoryType>("createCategory")
            .Argument<NonNullGraphType<CategoryInputType>>("category")
            .ResolveAsync(CreateCategory);

        Field<ProductType>("updateProduct")
            .Argument<IdGraphType>("id")
            .Argument<NonNullGraphType<ProductInputType>>("product")
            .ResolveAsync(UpdateProduct);

        Field<CategoryType>("updateCategory")
            .Argument<IdGraphType>("id")
            .Argument<NonNullGraphType<CategoryInputType>>("category")
            .ResolveAsync(UpdateCategory);

        Field<ProductType>("deleteProduct")
            .Argument<IdGraphType>("productId")
            .ResolveAsync(DeleteProduct);

        Field<CategoryType>("deleteCategory")
            .Argument<IdGraphType>("categoryId")
            .ResolveAsync(DeleteCategory);
    }

    private Func<IResolveFieldContext<object?>, Task<object?>> CreateProduct() =>
        async context =>
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
        };

    private async Task<object?> CreateCategory(IResolveFieldContext ctx)
    {
        var category = ctx.GetArgument<CategoryDto>("category");
        return await _mediator.Send(new CreateCategoryCommand(new CategoryRequest
        {
            Name = category.Name,
            Image = category.Image,
            ParentCategory = category.ParentCategory
        }));
    }

    private async Task<object?> UpdateProduct(IResolveFieldContext ctx)
    {
        int productId = ctx.GetArgument<int>("id");
        var product = ctx.GetArgument<ProductDto>("product");
        return await _mediator.Send(new UpdateProductCommand(new UpdateProductRequest
        {
            Id = productId,
            Name = product.Name,
            Description = product.Description,
            Image = product.Image,
            Price = product.Price,
            Amount = product.Amount,
            Category = product.Category
        }));
    }

    private async Task<object?> UpdateCategory(IResolveFieldContext ctx)
    {
        int categoryId = ctx.GetArgument<int>("id");
        var category = ctx.GetArgument<CategoryDto>("category");
        return await _mediator.Send(new UpdateCategoryCommand(new UpdateCategoryRequest
        {
            Id = categoryId,
            Name = category.Name,
            Image = category.Image,
            ParentCategory = category.ParentCategory
        }));
    }

    private async Task<object?> DeleteProduct(IResolveFieldContext ctx)
    {
        int productId = ctx.GetArgument<int>("productId");
        return await _mediator.Send(new RemoveProductCommand(productId));
    }

    private async Task<object?> DeleteCategory(IResolveFieldContext ctx)
    {
        int categoryId = ctx.GetArgument<int>("categoryId");
        return await _mediator.Send(new RemoveCategoryCommand(categoryId));
    }
}
