using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MecatolArchives.DataAccess.Models;

public class Person 
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Identifier { get; set; }

    [MaxLength(100)]
    public string Name { get; set; } = null!;
    public bool Active { get; set; } = false;

    public virtual Colour? DefaultColour { get; set; } = null;
}