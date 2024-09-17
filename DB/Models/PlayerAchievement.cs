using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hesketh.MecatolArchives.DB.Models;

public class PlayerAchievement : IEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Identifier { get; set; }

    public virtual Player Player { get; set; } = null!;
    public virtual Achievement Achievement { get; set; } = null!;

    public DateTime DateAccomplished { get; set; } = DateTime.MinValue;
}