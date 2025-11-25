namespace MecatolArchives.Domain.Dto;

public sealed record CreateColourRequest
{
    public required string Name { get; set; } = null!;
    public required string Hex { get; set; } = null!;
}
