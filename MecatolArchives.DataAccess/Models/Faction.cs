using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MecatolArchives.DataAccess.Models;

public class Faction 
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Identifier { get; set; }

    [MaxLength(100)]
    public string Name { get; set; } = null!;

    [MaxLength(500)]
    public string? Url { get; set; } = null;

    public bool Active { get; set; } = true;

    public virtual ICollection<FactionVariant> Variants { get; set; } = null!;
}