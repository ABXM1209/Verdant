using Application.Common.Interfaces.Services;
using Application.DTOs.GameSession;

namespace Application.Services;

public class GameSessionService : IGameSessionService
{
    public async Task<IEnumerable<GameEventDto>> ProcessActionAsync(string eventType, Guid sourceId, Guid targetId, string payload)
    {
        throw new NotImplementedException();
    }
}