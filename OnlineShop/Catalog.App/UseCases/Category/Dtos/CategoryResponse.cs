namespace Catalog.App.UseCases.Category.Dtos;

public class CategoryResponse
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string? Image { get; set; }

    public int? ParentCategoryId { get; set; }

    public string? ParentCategory { get; set; }
}
