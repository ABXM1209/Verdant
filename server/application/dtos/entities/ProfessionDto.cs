namespace Application.DTOs.Entities;

public sealed record ProfessionDto(Guid Id, string Name, string StarterAttribute, string StarterMastery);

public sealed record CreateProfessionDto
{
	public string Name { get; init; } = string.Empty;
	public string StarterAttribute { get; init; }
	public string StarterMastery { get; init; } = string.Empty;
}

public sealed record EditProfessionDto
{
	public Guid Id { get; init; }
	public string Name { get; init; } = string.Empty;
	public string StarterAttribute { get; init; }
	public string StarterMastery { get; init; } = string.Empty;
}