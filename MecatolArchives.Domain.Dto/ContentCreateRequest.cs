namespace MecatolArchives.Domain.Dto;

public sealed record ContentCreateRequest
{
    public required string Name { get; set; }
}