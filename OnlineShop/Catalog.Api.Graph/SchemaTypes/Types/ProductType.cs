using Catalog.App.UseCases.Product.Dtos;
using GraphQL.Types;

namespace Catalog.Api.Graph.SchemaTypes.Types;

public sealed class ProductType : ObjectGraphType<ProductResponse>
{
    public ProductType()
    {
        Name = "Product";
        Description = "A product in online store";
        Field(d => d.Id);
        Field(d => d.Name);
        Field(d => d.Description);
        Field(d => d.Image);
        Field(d => d.Price);
        Field(d => d.Amount);
        Field(d => d.CategoryId);
        Field(d => d.Category);
    }
}
