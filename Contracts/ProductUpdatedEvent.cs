namespace messaging.Contracts;

public record ProductUpdatedEvent(
    Guid Id,
    string Name,
    decimal Price,
    int Stock,
    string Description,
    DateTime UpdatedAt = default)
{
    public DateTime UpdatedAt { get; } = UpdatedAt == default ? DateTime.UtcNow : UpdatedAt;
}