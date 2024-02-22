namespace Hesketh.MecatolArchives.API.Data;

public sealed class Player : IEntity
{
    public uint Points { get; set; } = 0;
    public bool Winner { get; set; } = false;
    public bool Eliminated { get; set; } = false;
    public uint DraftOrder { get; set; } = 0;

    public Person Person { get; set; } = null!;
    public Faction Faction { get; set; } = null!;
    public Colour Colour { get; set; } = null!;
    public Guid Identifier { get; set; }
}