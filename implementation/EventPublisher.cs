// <copyright file="EventPublisher"
//Author="tjtechy">
//EcommerceMicroservicesDotNet
//Copyright (C) TJTECHY
//</copyright>


using messaging.Interfaces;
using Microsoft.Extensions.Logging;

namespace messaging.implementation;

public class EventPublisher: IEventPublisher
{
    private readonly ILogger<EventPublisher> _logger;
    private readonly IMessagePublisher _messagePublisher;
    private readonly IEventRouting _eventRouting;

    public EventPublisher(IMessagePublisher messagePublisher, ILogger<EventPublisher> logger, IEventRouting eventRouting)
    {
        _logger = logger;
        _messagePublisher = messagePublisher;
        _eventRouting = eventRouting;
    }
    
    
    public async Task PublishAsync<TEvent>(TEvent @event, CancellationToken ctx) where TEvent : class
    {
        ArgumentNullException.ThrowIfNull(@event);
        var destination = _eventRouting.GetDestinationForEvent<TEvent>();
        _logger.LogInformation("Publishing event of type {EventType} to destination {Destination}", typeof(TEvent).FullName, destination);
        await _messagePublisher.PublishAsync(@event, destination, ctx);
    }
}