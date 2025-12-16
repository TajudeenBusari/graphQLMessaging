// <copyright file="ProductCreatedEvent"
//Author="tjtechy">
//EcommerceMicroservicesDotNet
//Copyright (C) TJTECHY
//</copyright>


using common_utils.Shared.Domain;

namespace messaging.Contracts;

/// <summary>
/// the dto will be shared product and inventory service or other services
/// </summary>
public record ProductCreatedEvent(
    Guid Id,
    string Name,
    decimal Price,
    DateTime CreatedAt = default)
{
    public DateTime CreatedAt { get; } = CreatedAt == default ? DateTime.UtcNow : CreatedAt;
}