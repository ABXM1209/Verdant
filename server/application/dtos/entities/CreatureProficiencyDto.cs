namespace Application.DTOs.Entities;

public sealed record CreatureProficiencyDto(Guid Id, Guid CreatureId, Guid ProficiencyId, int Level);

public sealed record CreateCreatureProficiencyDto
{
	public Guid CreatureId { get; init; }
	public Guid ProficiencyId { get; init; }
	public int Level { get; init; }
}

public sealed record EditCreatureProficiencyDto
{
	public Guid Id { get; init; }
	public Guid CreatureId { get; init; }
	public Guid ProficiencyId { get; init; }
	public int Level { get; init; }
}