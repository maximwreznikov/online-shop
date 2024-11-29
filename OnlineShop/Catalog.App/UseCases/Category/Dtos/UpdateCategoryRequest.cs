namespace Catalog.App.UseCases.Category.Dtos;

public record UpdateCategoryRequest : CategoryRequest
{
    public int Id { get; init; }
}
