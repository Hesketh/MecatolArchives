using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hesketh.MecatolArchives.DB.Models;

public class Colour : IEntity, INamed
{
    public string Hex { get; set; } = null!;

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Identifier { get; set; }

    public string Name { get; set; } = null!;
}