using System.Text;

namespace MecatolArchives.Domain.Dto;

public record FactionVariants(FactionVariant[] Items)
{
    protected FactionVariants(FactionVariants other)
    {
        Items = other.Items.Select(x => x with { }).ToArray();
    }

    public virtual bool Equals(FactionVariants? other)
    {
        if (other is null)
            return false;

        foreach (var factionVariant in other.Items)
        {
            if (!Items.Contains(factionVariant))
            {
                return false;
            }
        }

        foreach (var factionVariant in Items)
        {
            if (!other.Items.Contains(factionVariant))
            {
                return false;
            }
        }

        return true;
    }

    public override int GetHashCode()
    {
        var hash = new HashCode();
        foreach (var item in Items) hash.Add(item);
        return hash.ToHashCode();
    }

    public override string ToString()
    {
        var sb = new StringBuilder();

        bool first = true;
        foreach (var item in Items)
        {
            if (!first)
            {
                sb.Append(", ");
            }
            first = false;

            sb.Append(item);
        }

        return sb.ToString();
    }
}