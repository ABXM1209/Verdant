using domain.enums;

namespace domain.entities;

public sealed record ElementalAffinity
{
    //   id, creature_id, element, affinity_type (primary/secondary/mutation)

    public Guid Id { get; init; } = Guid.NewGuid();
    public Guid creatureId { get; set; }
    public string Element { get; set; } = string.Empty; 
    public ElementalAffinityRoll AffinityType { get; set; } = ElementalAffinityRoll.OnePrimaryElement;
}