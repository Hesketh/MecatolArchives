namespace MecatolArchives.Domain.Dto;

public sealed record Variant
{
    public required Guid Identifier { get; set; }
    public required string Name { get; set; }
}