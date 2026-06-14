namespace Application.DTOs.Entities;

public sealed record ElementalAffinityDto(Guid Id, Guid CreatureId, int AffinityRoll, ICollection<string> Elements);

public sealed record CreateElementalAffinityDto
{
	public Guid CreatureId { get; init; }
	public int AffinityRoll { get; init; }
	public ICollection<string> Elements { get; init; } = new List<string>();
}

public sealed record EditElementalAffinityDto
{
	public Guid Id { get; init; }
	public Guid CreatureId { get; init; }
	public int AffinityRoll { get; init; }
	public ICollection<string> Elements { get; init; } = new List<string>();
}