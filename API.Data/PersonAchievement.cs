namespace Hesketh.MecatolArchives.API.Data;

public class PersonAchievement
{
    public Achievement Achievement { get; set; } = null!;
    public DateTime? DateAccomplished { get; set; } = null;
}