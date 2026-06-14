using Domain.Enums;

namespace Application.DTOs.Entities;

public sealed record PlayerProfessionDto(Guid Id, Guid PlayerId, Guid ProfessionId, ProfessionTierEnum CurrentTier);

public sealed record CreatePlayerProfessionDto
{
	public Guid PlayerId { get; init; }
	public Guid ProfessionId { get; init; }
}

public sealed record EditPlayerProfessionDto
{
	public Guid Id { get; init; }
	public Guid PlayerId { get; init; }
	public Guid ProfessionId { get; init; }
	public ProfessionTierEnum CurrentTier { get; init; }
}