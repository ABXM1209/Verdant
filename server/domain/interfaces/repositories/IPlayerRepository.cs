using domain.entities;

namespace domain.interfaces.repositories;

public interface IPlayerRepository : IBaseRepository<Player>
{
	// Add player-specific queries here in future (e.g. FindByCreatureId)
}