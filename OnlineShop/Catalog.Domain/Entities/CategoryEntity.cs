using Catalog.Domain.Abstractions;

namespace Catalog.Domain.Entities;

public class CategoryEntity : IEntity, INamedEntity
{
    public int Id { get; set; }
    
    public string Name { get; set; } = string.Empty;
    
    public string? Image { get; set; }
    
    public int? ParentCategoryId { get; set; }
    
    public string? ParentCategory { get; set; }
    
    public ICollection<ProductEntity> Products { get; set; } = new List<ProductEntity>();
}