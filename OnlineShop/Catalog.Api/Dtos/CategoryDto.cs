namespace Catalog.Api.Dtos;

public record CategoryDto(
    string Name,
    string? Image,
    string? ParentCategory);