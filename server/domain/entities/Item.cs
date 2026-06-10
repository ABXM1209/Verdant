using domain.enums;

namespace domain.entities;

public sealed record Item
{
    public Guid Id { get; init; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int Price { get; set; }
    public ItemWeightClass WeightClass { get; set; }
    public ItemType Type { get; set; }
}