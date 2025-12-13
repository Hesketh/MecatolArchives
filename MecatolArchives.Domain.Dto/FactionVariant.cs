namespace MecatolArchives.Domain.Dto;

public sealed record FactionVariant
{
    public required Guid Identifier { get; set; }
    public required string Name { get; set; }
}