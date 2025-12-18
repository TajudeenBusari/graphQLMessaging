// <copyright file="RabbitMQPublisher"
//Author="tjtechy">
//EcommerceMicroservicesDotNet
//Copyright (C) TJTECHY
//</copyright>


using messaging.Contracts;
using messaging.Interfaces;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;

namespace messaging.RabbitMq;

public class RabbitMqPublisher: IMessagePublisher, IAsyncDisposable
{
    private readonly ILogger<RabbitMqPublisher> _logger;
    private readonly IChannel _channel;
    private bool _disposed;
    public RabbitMqPublisher(ILogger<RabbitMqPublisher> logger, IChannel channel)
    {
        _logger = logger;
        _channel = channel;
    }
    
    
    public async Task PublishAsync<TMessage>(TMessage message, EventDestination destination, CancellationToken cancellationToken = default) where TMessage : class
    {
        ArgumentNullException.ThrowIfNull(message);
        ArgumentNullException.ThrowIfNull(destination);
        var body = System.Text.Json.JsonSerializer.SerializeToUtf8Bytes(message);
        _logger.LogInformation("Publishing message {MessageType} to exchange {Exchange} with routing key {RoutingKey}", typeof(TMessage).FullName, destination.ExchangeOrTopic, destination.RoutingKeyOrSubject);
        await _channel.BasicPublishAsync(
            exchange: destination.ExchangeOrTopic,
            routingKey: destination.RoutingKeyOrSubject, //or derived from routing strategy
            body: body,
            cancellationToken: cancellationToken
        );
    }


    public ValueTask DisposeAsync()
    {
        if (_disposed)
            return default;
        _disposed = true;
        _logger.LogInformation("Disposing RabbitMQ channel");
        GC.SuppressFinalize(this);
        return _channel.DisposeAsync();
    }
}