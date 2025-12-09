namespace MecatolArchives.Domain.Dto;

public sealed record VariantCreateRequest
{
    public required string Name { get; set; }
}