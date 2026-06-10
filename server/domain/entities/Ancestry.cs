using domain.enums;

namespace domain.entities;

public sealed record Ancestry
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public string Name { get; set; } = string.Empty;
    public int Lifespan { get; set; }
    public string Size { get; set; } = string.Empty;
    public ICollection<string> Elements { get; set; } = new List<string>();
}