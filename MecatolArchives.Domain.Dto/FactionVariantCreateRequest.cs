namespace MecatolArchives.Domain.Dto;

public sealed record FactionVariantCreateRequest
{
    public required string Name { get; set; }
}