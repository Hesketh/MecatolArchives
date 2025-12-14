namespace MecatolArchives.Domain.Dto;

public sealed record Faction
{
    public required Guid Identifier { get; set; }
    public required string Name { get; set; }
    public required string Url { get; set; }

    public FactionVariants Variants { get; set; } = new([]);
}