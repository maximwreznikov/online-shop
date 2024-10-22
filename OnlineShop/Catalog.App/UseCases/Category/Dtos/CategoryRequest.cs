namespace Catalog.App.UseCases.Category.Dtos;

public record CategoryRequest
{
    public string Name { get; init; } = string.Empty;
    
    public string? Image { get; init; }
    
    public string? ParentCategory { get; init; }
}