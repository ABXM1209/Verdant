namespace Application.DTOs.Entities;

public sealed record CreatureTechniqueDto(Guid Id, Guid CreatureId, Guid TechniqueId, int SkillLevel);

public sealed record CreateCreatureTechniqueDto
{
	public Guid CreatureId { get; init; }
	public Guid TechniqueId { get; init; }
	public int SkillLevel { get; init; }
}

public sealed record EditCreatureTechniqueDto
{
	public Guid Id { get; init; }
	public Guid CreatureId { get; init; }
	public Guid TechniqueId { get; init; }
	public int SkillLevel { get; init; }
}