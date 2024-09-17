using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hesketh.MecatolArchives.DB.Models;

public class Achievement : IEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Identifier { get; set; }

    [MinLength(0)]
    [MaxLength(512)]
    public string Title { get; set; } = string.Empty;

    [MinLength(0)]
    [MaxLength(1024)]
    public string Condition { get; set; } = string.Empty;

    public virtual ICollection<PlayerAchievement> Players { get; set; } = new List<PlayerAchievement>();    
}