namespace Domain.Entities;

public sealed record CreatureProficiency
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public Guid CreatureId { get; set; }
    public Guid ProficiencyId { get; set; }
    public int Level { get; set; }
}