using System.ComponentModel.DataAnnotations;

namespace Cart.DAL;

public class LiteDbOptions
{
    [Required] public string DatabaseLocation { get; set; } = string.Empty;
}
