namespace Hesketh.MecatolArchives.API.Data.Put;

public sealed class Person
{
    public Guid Identifier { get; set; }
    public string Name { get; set; } = null!;
    public Guid? DefaultColourId { get; set; } = null;
}