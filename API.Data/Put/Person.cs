namespace Hesketh.MecatolArchives.API.Data.Put;

public sealed class Person : IEntity
{
    public Person() {}

    public Person(Data.Person person)
    {
        Identifier = person.Identifier;
        Name = person.Name;
        DefaultColourId = person.DefaultColour?.Identifier;
        HideFromStatistics = person.HideFromStatistics;
    }
    
    public Guid Identifier { get; set; }
    public string Name { get; set; } = null!;
    public bool HideFromStatistics { get; set; } = false;
    public Guid? DefaultColourId { get; set; } = null;
}