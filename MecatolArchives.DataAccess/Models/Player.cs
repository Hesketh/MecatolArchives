using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MecatolArchives.DataAccess.Models;

public class Player
{
    public uint Points { get; set; } = 0;
    public bool Winner { get; set; } = false;
    public bool Eliminated { get; set; } = false;
    public uint DraftOrder { get; set; } = 0;

    public virtual Person Person { get; set; } = null!;
    public virtual Play Play { get; set; } = null!;
    public virtual Faction Faction { get; set; } = null!;
    public virtual Colour Colour { get; set; } = null!;

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Identifier { get; set; }
}