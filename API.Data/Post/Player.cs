namespace Hesketh.MecatolArchives.API.Data.Post;

public sealed class Player
{
    public Player() {}
    public Player(Data.Player model)
    {
        Points = model.Points;
        Winner = model.Winner;
        Eliminated = model.Eliminated;

        PersonIdentifier = model.Person.Identifier;
        FactionIdentifier = model.Faction.Identifier;
        ColourIdentifier = model.Colour.Identifier;
    }

    public uint Points { get; set; } = 0;
    public bool Winner { get; set; } = false;
    public bool Eliminated { get; set; } = false;

    public Guid PersonIdentifier { get; set; }
    public Guid FactionIdentifier { get; set; }
    public Guid ColourIdentifier { get; set; }
}