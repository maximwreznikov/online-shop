namespace Catalog.Contracts;

public record CategoryDto(
    string Name,
    string? Image,
    string? ParentCategory);
