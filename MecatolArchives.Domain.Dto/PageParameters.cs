namespace MecatolArchives.Domain.Dto;

public sealed record PageParameters
{
    public int Number { get; set; } = 1;
    public int Size { get; set; } = 10;
}
