using System.ComponentModel.DataAnnotations;

namespace Hesketh.MecatolArchives.API.Data;

public class Achievement : IEntity
{
    public Guid Identifier { get; set; }

    [MinLength(0)]
    [MaxLength(512)]
    public string Name { get; set; } = string.Empty;

    [MinLength(0)]
    [MaxLength(1024)]
    public string Condition { get; set; } = string.Empty;
}