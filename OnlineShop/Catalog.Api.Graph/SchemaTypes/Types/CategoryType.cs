using Catalog.App.UseCases.Category.Dtos;
using GraphQL.Types;

namespace Catalog.Api.Graph.SchemaTypes.Types;

public sealed class CategoryType : ObjectGraphType<CategoryResponse>
{
    public CategoryType()
    {
        Name = "Category";
        Field(d => d.Id);
        Field(d => d.Name);
        Field(d => d.Image);
        Field(d => d.ParentCategoryId);
        Field(d => d.ParentCategory);
    }
}
