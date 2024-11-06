namespace Catalog.Api.Dtos;

public record AddToCartDto
(
    Guid CartId,
    int ProductId,
    int Amount
);
    