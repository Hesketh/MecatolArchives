namespace Hesketh.MecatolArchives.API.Data.Post;

public sealed class Play
{
    public DateTime UtcDate { get; set; } = DateTime.Now;
    public double RulesVersion { get; set; } = 1.0;
    public uint PointGoal { get; set; } = 10;
    public string? Map { get; set; } = null;

    public ICollection<Guid> VariantIdentifiers { get; set; } = new HashSet<Guid>();
    public ICollection<Guid> ExpansionIdentifiers { get; set; } = new HashSet<Guid>();
    public ICollection<Player> Players { get; set; } = new HashSet<Player>();
}