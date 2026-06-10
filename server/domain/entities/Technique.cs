using domain.enums;

namespace domain.entities;

public sealed record Technique
//  id, name, type (innate/learnable/extension), required skill or list of skills, description
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public string Name { get; set; } = string.Empty;
    public TechniqueType Type { get; set; }
    public string RequiredSkill { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}