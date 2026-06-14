namespace Application.DTOs.GameSession;

public sealed record GameEventDto(
    string EventType, // e.g. "HpChanged", "CreatureDied", "TechniqueUsed", "PlayerJoined"
    Guid SourceId, // creature/player that caused the event
    Guid? TargetId, // creature/player that was affected, if any
    string Payload // JSON string for flexible event-specific data
);
