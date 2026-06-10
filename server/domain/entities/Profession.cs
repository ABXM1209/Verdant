using domain.enums;

namespace domain.entities;

public sealed record Profession
{
    //   id, name, tier, starter_attribute, starter_mastery
    public Guid Id { get; init; } = Guid.NewGuid();
    public string Name { get; set; } = string.Empty; 
    public ProfessionTier Tier { get; set; } = ProfessionTier.Novice;
    public int StarterAttribute { get; set; }
    public string StarterMastery { get; set; } = string.Empty;
}