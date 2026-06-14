using Domain.Enums;

namespace Application.DTOs.Entities;

public sealed record TechniqueDto(Guid Id, string Name, TechniqueTypeEnum Type, string RequiredSkill, string Description);

public sealed record CreateTechniqueDto
{
	public string Name { get; init; } = string.Empty;
	public TechniqueTypeEnum Type { get; init; }
	public string RequiredSkill { get; init; } = string.Empty;
	public string Description { get; init; } = string.Empty;
}

public sealed record EditTechniqueDto
{
	public Guid Id { get; init; }
	public string Name { get; init; } = string.Empty;
	public TechniqueTypeEnum Type { get; init; }
	public string RequiredSkill { get; init; } = string.Empty;
	public string Description { get; init; } = string.Empty;
}