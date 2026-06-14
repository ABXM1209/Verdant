using System.Security.Claims;
using Application.DTOs.GameSession;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace Api.Hubs;

[Authorize]
public class GameHub : Hub<IGameHubClient>
{
    // Extracts the authenticated user's ID from the JWT — same claim as BaseController.
    private Guid UserId => Guid.Parse(
        Context.User!.FindFirstValue(ClaimTypes.NameIdentifier)!);

    public override async Task OnConnectedAsync()
    {
        await base.OnConnectedAsync();
        // TODO: inject IGameSessionService, load the player's session state,
        //       and send their initial state back via Clients.Caller.ReceiveGameEvent(...)
    }

    public override async Task OnDisconnectedAsync(Exception? exception)
    {
        // TODO: flush session state (current HP/SP, position) back to the database.
        await base.OnDisconnectedAsync(exception);
    }

    // Called by Godot when the player enters a scene/zone/dungeon.
    // sceneId is a string key like "overworld", "dungeon-3", etc.
    public async Task JoinScene(string sceneId)
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, sceneId);

        // Broadcast to everyone already in the scene that a player joined.
        await Clients.OthersInGroup(sceneId).ReceiveGameEvent(
            new GameEventDto("PlayerJoined", UserId, null, sceneId));
    }

    public async Task LeaveScene(string sceneId)
    {
        await Groups.RemoveFromGroupAsync(Context.ConnectionId, sceneId);

        await Clients.OthersInGroup(sceneId).ReceiveGameEvent(
            new GameEventDto("PlayerLeft", UserId, null, sceneId));
    }

    // Called by Godot when the player takes an action (attack, use item, cast technique, etc.).
    // sceneId tells the hub which group to broadcast the result to.
    public async Task SendAction(string sceneId, PlayerActionDto action)
    {
        // TODO: inject IGameSessionService, pass the action through game logic,
        //       get back one or more GameEventDtos, and broadcast them to the group.
        //
        // For now, echo the action back to the group so the wire-up can be tested
        // before game logic is implemented.
        var echo = new GameEventDto("ActionReceived", UserId, action.TargetId, action.ActionType);
        await Clients.Group(sceneId).ReceiveGameEvent(echo);
    }
}
