// <copyright file="DefaultEventRouting"
//Author="tjtechy">
//EcommerceMicroservicesDotNet
//Copyright (C) TJTECHY
//</copyright>


using messaging.Contracts;
using messaging.Interfaces;

namespace messaging.implementation;

public class DefaultEventRouting: IEventRouting
{
    public EventDestination GetDestinationForEvent<TEvent>() => typeof(TEvent).Name switch
    {
        nameof(ProductCreatedEvent) => new EventDestination(ExchangeOrTopic: "product.exchange", RoutingKeyOrSubject: "product.created"),
        //Add more event types and their destinations here: e.g., ProductUpdatedEvent, OrderPlacedEvent, etc.
        nameof(ProductUpdatedEvent) => new EventDestination(ExchangeOrTopic: "product.exchange", RoutingKeyOrSubject: "product.updated"),
        nameof(ProductDeletedEvent) => new EventDestination(ExchangeOrTopic: "product.exchange", RoutingKeyOrSubject: "product.deleted"),
        _ => throw new ArgumentException($"No destination configured for event type {typeof(TEvent).FullName}")
    };
}