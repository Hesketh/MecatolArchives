namespace Hesketh.MecatolArchives.API.Data;

public sealed class Expansion : IEntity
{
    public string Name { get; set; } = null!;
    public Guid Identifier { get; set; }
}