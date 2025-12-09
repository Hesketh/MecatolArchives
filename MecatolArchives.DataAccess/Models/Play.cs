using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MecatolArchives.DataAccess.Models;

public class Play 
{
    public DateTime UtcDate { get; set; } = DateTime.UtcNow;
    public double RulesVersion { get; set; } = 1.0;
    public uint PointGoal { get; set; } = 10;
    public string? Map { get; set; } = null;

    public virtual ICollection<Player> Players { get; set; } = null!;
    public virtual ICollection<Content> Expansions { get; set; } = null!;
    public virtual ICollection<Variant> Variants { get; set; } = null!;

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Identifier { get; set; }

    [NotMapped] public string Name => UtcDate.ToString("yyyy-MM-dd");
}