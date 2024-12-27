using Catalog.Contracts;
using GraphQL.Types;

namespace Catalog.Api.Graph.SchemaTypes.Types;

public sealed class ProductInputType : InputObjectGraphType<ProductDto>
{
    public ProductInputType()
    {
        Name = "ProductInput";
        Field(x => x.Name);
        Field(x => x.Description, nullable: true);
        Field(x => x.Image, nullable: true);
        Field(x => x.Price, nullable: false);
        Field(x => x.Amount, nullable: false);
        Field(x => x.Category, nullable: false);
    }
}
