namespace MecatolArchives.Domain.Dto;

public sealed record FactionUpdateRequest
{
    public string? Name { get; set; }
    public string? Url { get; set; }
}