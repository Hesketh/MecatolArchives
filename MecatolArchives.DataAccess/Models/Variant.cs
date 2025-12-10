using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MecatolArchives.DataAccess.Models;

public class Variant 
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Identifier { get; set; }

    [MaxLength(100)]
    public string Name { get; set; } = null!;

    public virtual ICollection<Play> Plays { get; set; } = null!;
}