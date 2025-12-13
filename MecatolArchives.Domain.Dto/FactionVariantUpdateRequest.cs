namespace MecatolArchives.Domain.Dto;

public sealed record FactionVariantUpdateRequest
{
    public required string Name { get; set; }
}