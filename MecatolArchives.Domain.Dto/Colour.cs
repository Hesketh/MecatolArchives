namespace MecatolArchives.Domain.Dto;

public sealed record Colour
{
    public Guid Identifier { get; set; }

    public string Name { get; set; } = null!;
    public string Hex { get; set; } = null!;
}
