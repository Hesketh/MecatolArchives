namespace Hesketh.MecatolArchives.API.Data.Post;

public sealed class Faction
{
    public string Name { get; set; } = null!;
    public bool HideFromStatistics { get; set; } = false;   
    public string? Link { get; set; } = null;
}