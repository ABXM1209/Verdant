using Domain.Entities;

namespace Domain.Interfaces.Repositories;

public interface IPlayerRepository : IBaseRepository<Player>
{
	// Add player-specific queries here in future (e.g. FindByCreatureId)
}