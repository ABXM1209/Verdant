using Domain.Enums;

namespace Domain.Entities;

public sealed record PlayerProfession
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public Guid PlayerId { get; set; }
    public Guid ProfessionId { get; set; }
    public ProfessionTierEnum CurrentTier { get; set; } = ProfessionTierEnum.Novice;
    // XP / Progression Method Later
}