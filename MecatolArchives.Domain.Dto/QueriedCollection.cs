namespace MecatolArchives.Domain.Dto;

public sealed record QueriedCollection<T> where T : class
{
    public ICollection<T> Items { get; set; } = new HashSet<T>();

    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;

    public int TotalCount { get; set; } = 0;
}
