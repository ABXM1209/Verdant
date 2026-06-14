using Domain.Enums;

namespace Domain.Entities;

public sealed record Item
{
    public Guid Id { get; init; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int Price { get; set; }
    public ItemWeightClassEnum WeightClassEnum { get; set; }
    public ItemTypeEnum TypeEnum { get; set; }
}