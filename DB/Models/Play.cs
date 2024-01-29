using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hesketh.MecatolArchives.DB.Models;

public class Play : IEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Identifier { get; set; }

    public DateTime UtcDate { get; set; } = DateTime.Now;
    public double RulesVersion { get; set; } = 1.0;
    public uint PointGoal { get; set; } = 10;
    public string? Map { get; set; } = null;
        
    public virtual ICollection<Player> Players { get; set; } = null!;
    public virtual ICollection<Expansion> Expansions { get; set; } = null!;
    public virtual Variant Variant { get; set; } = null!;
}