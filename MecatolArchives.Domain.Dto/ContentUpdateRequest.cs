namespace MecatolArchives.Domain.Dto;

public sealed record ContentUpdateRequest
{
    public string? Name { get; set; }
}