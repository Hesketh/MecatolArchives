using System.ComponentModel.DataAnnotations;

namespace MecatolArchives.Domain.Dto;

public sealed record Play
{
    public required Guid Identifier { get; set; }

    public required DateTime UtcDate { get; set; }
    public required double RulesVersion { get; set; }
    public required uint PointGoal { get; set; }

    [MaxLength(500)]
    public string? Map { get; set; } = null;

    public required Players Players { get; set; } = null!;
    public required Contents Expansions { get; set; } = null!;
    public required Variants Variants { get; set; } = null!;
}