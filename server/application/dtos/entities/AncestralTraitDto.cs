namespace Application.DTOs.Entities;

public sealed record AncestralTraitDto(Guid Id, Guid AncestryId, string Name, string Description);

public sealed record CreateAncestralTraitDto
{
	public Guid AncestryId { get; init; }
	public string Name { get; init; } = string.Empty;
	public string Description { get; init; } = string.Empty;
}

public sealed record EditAncestralTraitDto
{
	public Guid Id { get; init; }
	public Guid AncestryId { get; init; }
	public string Name { get; init; } = string.Empty;
	public string Description { get; init; } = string.Empty;
}