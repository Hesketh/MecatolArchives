namespace Hesketh.MecatolArchives.API.Data.Put;

public sealed class Play : IEntity
{
    public Play() {}
    public Play(Data.Play model)
    {
        Identifier = model.Identifier;

        UtcDate = model.UtcDate;
        RulesVersion = model.RulesVersion;
        PointGoal = model.PointGoal;
        Map = model.Map;

        VariantIdentifiers = new List<Guid>(model.Variants.Select(x => x.Identifier));
        ExpansionIdentifiers = new List<Guid>(model.Expansions.Select(x => x.Identifier));
        Players = new List<Post.Player>(model.Players.Select(x => new Post.Player(x)));
    }

    public Guid Identifier { get; set; }

    public DateTime UtcDate { get; set; } = DateTime.Now;
    public double RulesVersion { get; set; } = 1.0;
    public uint PointGoal { get; set; } = 10;
    public string? Map { get; set; } = null;

    public ICollection<Guid> VariantIdentifiers { get; set; } = new HashSet<Guid>();
    public ICollection<Guid> ExpansionIdentifiers { get; set; } = new HashSet<Guid>();
    public ICollection<Post.Player> Players { get; set; } = new HashSet<Post.Player>();
}