using System.ComponentModel.DataAnnotations;

namespace MecatolArchives.Domain.Dto;

public sealed record PlayCreateRequest
{
    public required DateTime UtcDate { get; set; } = DateTime.UtcNow;
    public required double RulesVersion { get; set; }
    public required uint PointGoal { get; set; }

    [MaxLength(500)]
    public string? Map { get; set; } = null;

    public required PlayerCreateRequests Players { get; set; } = null!;
    public required GuidCollection Expansions { get; set; } = null!;
    public required GuidCollection Variants { get; set; } = null!;
}