// <copyright file="IPublisher"
//Author="tjtechy">
//EcommerceMicroservicesDotNet
//Copyright (C) TJTECHY
//</copyright>


namespace messaging.Interfaces;

public interface IEventPublisher
{
   Task PublishAsync<TEvent>(TEvent @event, CancellationToken cancellationToken = default) where TEvent: class;
    
}