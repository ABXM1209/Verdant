namespace Domain.Entities;

public sealed record Ancestry
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public string Name { get; set; } = string.Empty;
    public int Lifespan { get; set; }
    public string Size { get; set; } = string.Empty;
    public ICollection<string> Elements { get; set; } = new List<string>();
    public string Description { get; set; } = string.Empty;
    public ICollection<AncestralTrait> AncestralTraits { get; set; } = new List<AncestralTrait>();
}