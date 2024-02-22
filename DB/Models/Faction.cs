using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hesketh.MecatolArchives.DB.Models;

public class Faction : IEntity, INamed
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Identifier { get; set; }

    public string Name { get; set; } = null!;
    public string? Link { get; set; } = null;
    public bool HideFromStatistics { get; set; } = false;
}