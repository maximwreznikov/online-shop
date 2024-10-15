namespace Catalog.App.Dtos;

public record ProductResponse
(
    int Id, 
    string Name, 
    string? Description,
    string? Image,
    decimal Price,
    uint Amount,
    string Category
);
    