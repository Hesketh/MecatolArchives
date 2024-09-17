namespace Hesketh.MecatolArchives.API.Data;

public class PlayerAchievement
{
    public Achievement Achievement { get; set; } = null!;
    public bool Accomplished { get; set; } = false;
}