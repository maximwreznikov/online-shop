using System.ComponentModel.DataAnnotations;

namespace Catalog.Contracts;

public record AddToCartDto
(
    [Required] Guid CartId,
    [Required] int ProductId,
    [Required] int Amount
);
