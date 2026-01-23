using System.ComponentModel.DataAnnotations;

namespace MecatolArchives.Domain.Dto;

public sealed record PlayUpdateRequest
{
    public DateTime? UtcDate { get; set; } = null;
    public double? RulesVersion { get; set; } = null;
    public uint? PointGoal { get; set; } = null;

    [MaxLength(500)]
    public string? Map { get; set; } = null;

    public GuidCollection? Expansions { get; set; } = null;
    public GuidCollection? Variants { get; set; } = null;
}