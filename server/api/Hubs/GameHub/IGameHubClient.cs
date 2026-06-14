using Application.DTOs.GameSession;

namespace Api.Hubs;

// Defines what the SERVER can push to CLIENTS.
// Every method here is something Godot must implement a listener for.
public interface IGameHubClient
{
    Task ReceiveGameEvent(GameEventDto gameEvent);
    Task ReceiveError(string message);
}
