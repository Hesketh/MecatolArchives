namespace MecatolArchives.Domain.Dto;

public sealed record PlayerCreateRequest
{
    public required uint Points { get; set; } = 0;
    public required bool Winner { get; set; } = false;
    public required bool Eliminated { get; set; } = false;
    public required uint DraftOrder { get; set; } = 0;

    public required Guid PersonIdentifier { get; set; } 
    public required Guid FactionIdentifier { get; set; } 
    public required Guid ColourIdentified { get; set; } 
}