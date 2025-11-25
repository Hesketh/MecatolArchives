namespace MecatolArchives.Domain.Dto;

public sealed record QueryParameters
{
    public PageParameters Page { get; set; } = new PageParameters();
}
