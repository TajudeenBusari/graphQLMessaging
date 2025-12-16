// <copyright file="IMessagePublisher"
//Author="tjtechy">
//EcommerceMicroservicesDotNet
//Copyright (C) TJTECHY
//</copyright>


namespace messaging.Interfaces;

public interface IMessagePublisher
{
    Task PublishAsync<TMessage>(TMessage message, string destination, CancellationToken cancellationToken = default) where TMessage : class;
}