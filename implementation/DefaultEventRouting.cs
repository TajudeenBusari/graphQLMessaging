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
    public string GetDestinationForEvent<TEvent>() => typeof(TEvent).Name switch
    {
        nameof(ProductCreatedEvent) => "product-created-event",
        _ => throw new ArgumentException($"No destination configured for event type {typeof(TEvent).FullName}")
    };
}