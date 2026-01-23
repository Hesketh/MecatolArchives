namespace MecatolArchives.Domain.Dto;

public sealed record PlayerUpdateRequest
{
    public uint? Points { get; set; } = null;
    public bool? Winner { get; set; } = null;
    public bool? Eliminated { get; set; } = null;
    public uint? DraftOrder { get; set; } = null;

    public Guid? PersonIdentifier { get; set; } = null;
    public Guid? FactionIdentifier { get; set; } = null;
    public Guid? ColourIdentified { get; set; } = null;
}