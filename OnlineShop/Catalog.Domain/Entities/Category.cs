namespace Catalog.Domain.Entities;

public class Category
{
    public string Name { get; set; } = string.Empty;
    
    public string? Image { get; set; }
    
    public string? ParentCategory { get; set; }
}