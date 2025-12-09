namespace MecatolArchives.Domain.Dto;

public sealed record PersonUpdateRequest
{
    public string Name { get; set; } = null!;
}
