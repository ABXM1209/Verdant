using Domain.Enums;

namespace Domain.Entities;

public sealed record ElementalAffinity
{
    
    public Guid Id { get; init; } = Guid.NewGuid();
    public Guid CreatureId { get; set; }
    public ElementalAffinityRollEnum AffinityRoll { get; set; } = ElementalAffinityRollEnum.OnePrimaryElement;
    public ICollection<string> Elements { get; set; } = new List<string>();
}