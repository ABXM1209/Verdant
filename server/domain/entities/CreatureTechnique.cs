namespace Domain.Entities;

public sealed record CreatureTechnique
{
    //   creature_id, technique_id, skill_level
    public Guid Id { get; init; } = Guid.NewGuid();
    public Guid CreatureId { get; set; }
    public Guid TechniqueId { get; set; }
    public int SkillLevel { get; set; }
}