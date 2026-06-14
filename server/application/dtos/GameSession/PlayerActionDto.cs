namespace Application.DTOs.GameSession;

public sealed record PlayerActionDto(
    string ActionType,  // e.g. "Attack", "UseItem", "CastTechnique"
    Guid? TargetId,     // creature being targeted, if any
    Guid? ItemId,       // item used, if any
    Guid? TechniqueId   // technique used, if any
);
