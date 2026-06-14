using Domain.Enums;

namespace Domain.Entities;

public sealed record Proficiency
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public string Name { get; set; } = string.Empty;
    public ProficiencyCategoryEnum CategoryEnum { get; set; }
    public string Description { get; set; } = string.Empty;
}