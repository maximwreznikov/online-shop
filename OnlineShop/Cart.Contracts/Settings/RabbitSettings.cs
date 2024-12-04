using System.ComponentModel.DataAnnotations;

namespace Cart.Contracts.Settings;

public class RabbitSettings
{
    [Required]
    public string Host { get; init; } = string.Empty;

    [Required]
    public string Username { get; init; } = string.Empty;

    [Required]
    public string Password { get; init; } = string.Empty;
}
