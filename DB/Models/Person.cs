using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hesketh.MecatolArchives.DB.Models;

public class Person : IEntity, INamed
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Identifier { get; set; }

    public string Name { get; set; } = null!;
    public bool HideFromStatistics { get; set; } = false;

    public virtual ICollection<PersonAchievement> Achievements { get; set; } = new List<PersonAchievement>();

    public virtual Colour? DefaultColour { get; set; } = null;
}