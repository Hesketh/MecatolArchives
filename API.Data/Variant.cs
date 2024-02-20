namespace Hesketh.MecatolArchives.API.Data;

public sealed class Variant : IEntity
{
    public string Name { get; set; } = null!;
    public Guid Identifier { get; set; }
}