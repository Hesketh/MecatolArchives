using System.Text;

namespace Hesketh.MecatolArchives.API.Data;

public sealed class Person : IEntity
{
    public string Name { get; set; } = null!;
    public Colour? DefaultColour { get; set; } = null;
    public Guid Identifier { get; set; }
    public bool HideFromStatistics { get; set; } = false;
    
    public string Initials
    {
        get
        {
            if (string.IsNullOrEmpty(Name))
                return string.Empty;
            
            var sb = new StringBuilder();
            var split = Name.Split(' ');

            foreach (var item in split)
            {
                var firstCharacter = item[0];
                sb.Append(firstCharacter);
            }

            return sb.ToString();
        }
    }
}