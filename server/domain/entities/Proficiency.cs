using domain.enums;

namespace domain.entities;

public sealed record Proficiency
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public string Name { get; set; } = string.Empty;
    public ProficiencyCategory Category { get; set; }
}