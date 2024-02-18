namespace Hesketh.MecatolArchives.API.Data;

public sealed class Play : IEntity
{
    public DateTime UtcDate { get; set; } = DateTime.UtcNow;
    public double RulesVersion { get; set; } = 1.0;
    public uint PointGoal { get; set; } = 10;
    public string? Map { get; set; } = null;

    public ICollection<Player> Players { get; set; } = null!;
    public ICollection<Expansion> Expansions { get; set; } = null!;
    public ICollection<Variant> Variants { get; set; } = null!;
    public Guid Identifier { get; set; }
}