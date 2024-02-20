using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hesketh.MecatolArchives.DB.Models;

public class Variant : IEntity, INamed
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Identifier { get; set; }

    public string Name { get; set; } = null!;
    
    public virtual ICollection<Play> Plays { get; set; } = null!;
}