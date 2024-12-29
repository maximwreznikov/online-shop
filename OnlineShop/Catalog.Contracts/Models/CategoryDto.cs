namespace Catalog.Contracts.Models;

public record CategoryDto(
    string Name,
    string? Image,
    string? ParentCategory);
