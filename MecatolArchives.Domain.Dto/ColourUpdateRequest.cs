namespace MecatolArchives.Domain.Dto;

public sealed record ColourUpdateRequest
{
    public string? Name { get; set; } = null;
    public string? Hex { get; set; } = null;
}
