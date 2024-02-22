namespace Hesketh.MecatolArchives.API.Data.Post;

public sealed class Person
{
    public string Name { get; set; } = null!;
    public Guid? DefaultColourId { get; set; } = null;
    public bool HideFromStatistics { get; set; } = false;
}