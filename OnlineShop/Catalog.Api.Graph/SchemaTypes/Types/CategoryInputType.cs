using Catalog.Contracts;
using GraphQL.Types;

namespace Catalog.Api.Graph.SchemaTypes.Types;

public sealed class CategoryInputType : InputObjectGraphType<CategoryDto>
{
    public CategoryInputType()
    {
        Name = "CategoryInput";
        Field(x => x.Name);
        Field(x => x.Image, nullable: true);
        Field(x => x.ParentCategory, nullable: true);
    }
}
