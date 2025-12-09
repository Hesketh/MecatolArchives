namespace MecatolArchives.Domain.Dto;

public sealed record Person
{
    public Guid Identifier { get; set; }
    public string Name { get; set; } = null!;
}
