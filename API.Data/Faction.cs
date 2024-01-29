namespace Hesketh.MecatolArchives.API.Data;

public sealed class Faction : IEntity
{
    public Guid Identifier { get; set; }
    public string Name { get; set; } = null!;
}