using Application.DTOs.GameSession;

namespace Application.Common.Interfaces.Services;

public interface IGameSessionService
{
    Task<IEnumerable<GameEventDto>> ProcessActionAsync(string eventType, Guid sourceId, Guid targetId,string payload);
}