namespace MecatolArchives.Domain.Dto;

public sealed record PersonCreateRequest
{
    public string Name { get; set; } = null!;
}
