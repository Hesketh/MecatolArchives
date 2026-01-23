using System.Text;

namespace MecatolArchives.Domain.Dto;

public record PlayerCreateRequests(PlayerCreateRequest[] Items)
{
    protected PlayerCreateRequests(PlayerCreateRequests other)
    {
        Items = other.Items.Select(x => x with { }).ToArray();
    }

    public virtual bool Equals(PlayerCreateRequests? other)
    {
        if (other is null)
            return false;

        foreach (var playerCreateRequest in other.Items)
        {
            if (!Items.Contains(playerCreateRequest))
            {
                return false;
            }
        }

        foreach (var playerCreateRequest in Items)
        {
            if (!other.Items.Contains(playerCreateRequest))
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