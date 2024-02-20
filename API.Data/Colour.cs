namespace Hesketh.MecatolArchives.API.Data;

public sealed class Colour : IEntity
{
    public string Name { get; set; } = null!;
    public string Hex { get; set; } = null!;
    public Guid Identifier { get; set; }
}