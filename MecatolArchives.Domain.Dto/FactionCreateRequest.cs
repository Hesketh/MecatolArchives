namespace MecatolArchives.Domain.Dto;

public sealed record FactionCreateRequest
{
    public required string Name { get; set; }
    public string Url { get; set; } = string.Empty;
}