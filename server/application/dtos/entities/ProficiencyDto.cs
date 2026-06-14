namespace Application.DTOs.Entities;

public sealed record ProficiencyDto(Guid Id, string Name, int Category, string Description);

public sealed record CreateProficiencyDto
{
	public string Name { get; init; } = string.Empty;
	public int Category { get; init; }
	public string Description { get; init; } = string.Empty;
}

public sealed record EditProficiencyDto
{
	public Guid Id { get; init; }
	public string Name { get; init; } = string.Empty;
	public int Category { get; init; }
	public string Description { get; init; } = string.Empty;
}