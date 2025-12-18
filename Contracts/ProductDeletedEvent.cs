// <copyright file="ProductDeletedEvent"
//Author="tjtechy">
//EcommerceMicroservicesDotNet
//Copyright (C) TJTECHY
//</copyright>


namespace messaging.Contracts;

public record ProductDeletedEvent(
    Guid Id,
    
    DateTime DeletedAt = default
)
{
    public DateTime DeletedAt { get; } = DeletedAt == default ? DateTime.UtcNow : DeletedAt;
}