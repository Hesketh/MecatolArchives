namespace Hesketh.MecatolArchives.API.Data;

public sealed class Faction : IEntity
{
    public string Name { get; set; } = null!;
    public bool HideFromStatistics { get; set; } = false;
    public string? Link { get; set; } = null;
    public Guid Identifier { get; set; }
}