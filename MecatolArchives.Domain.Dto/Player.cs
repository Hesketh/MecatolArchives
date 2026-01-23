namespace MecatolArchives.Domain.Dto;

public sealed record Player
{
    public required Guid Identifier { get; set; }

    public required uint Points { get; set; } = 0;
    public required bool Winner { get; set; } = false;
    public required bool Eliminated { get; set; } = false;
    public required uint DraftOrder { get; set; } = 0;

    public required Person Person { get; set; } = null!;
    public required Faction Faction { get; set; } = null!;
    public required Colour Colour { get; set; } = null!;
}