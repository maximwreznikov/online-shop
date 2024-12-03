using System.ComponentModel.DataAnnotations;

namespace Catalog.Api.Dtos;

public record AddToCartDto
(
    [Required] Guid CartId,
    [Required] int ProductId,
    [Required] int Amount
);
