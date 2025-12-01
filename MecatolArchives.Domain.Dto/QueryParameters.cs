namespace MecatolArchives.Domain.Dto;

public sealed record QueryParameters
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}
