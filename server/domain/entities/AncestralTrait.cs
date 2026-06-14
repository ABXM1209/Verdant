namespace Domain.Entities;

public sealed record AncestralTrait
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public Guid AncestryId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    
}