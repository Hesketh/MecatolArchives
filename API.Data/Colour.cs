namespace Hesketh.MecatolArchives.API.Data;

public sealed class Colour : IEntity
{
    public Guid Identifier { get; set; }
    public string Name { get; set; } = null!;
    public string Hex { get; set; } = null!;
}