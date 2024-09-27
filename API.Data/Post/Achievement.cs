using System.ComponentModel.DataAnnotations;

namespace Hesketh.MecatolArchives.API.Data.Post;

public class Achievement
{
    [MinLength(0)]
    [MaxLength(512)]
    public string Name { get; set; } = string.Empty;

    [MinLength(0)]
    [MaxLength(1024)]
    public string Condition { get; set; } = string.Empty;
}