namespace MecatolArchives.Domain.Dto;

public sealed record Content
{
    public required Guid Identifier { get; set; }
    public required string Name { get; set; }
}