namespace Hesketh.MecatolArchives.API.Data;

public sealed class Person : IEntity
{
    public Guid Identifier { get; set; }
    public string Name { get; set; } = null!;
}