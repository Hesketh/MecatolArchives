namespace MecatolArchives.Domain.Dto;

public sealed record UpdateColourRequest
{
    public string? Name { get; set; } = null;
    public string? Hex { get; set; } = null;
}
