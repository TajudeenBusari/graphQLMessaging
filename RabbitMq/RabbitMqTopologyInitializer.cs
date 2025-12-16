// <copyright file="RabbitMqTopologyInitializer"
//Author="tjtechy">
//EcommerceMicroservicesDotNet
//Copyright (C) TJTECHY
//</copyright>


using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;

namespace messaging.RabbitMq;

public class RabbitMqTopologyInitializer: IHostedService
{
    private readonly IChannel _channel;
    public RabbitMqTopologyInitializer(IChannel channel)
    {
        _channel = channel;
    }
    
    public async Task StartAsync(CancellationToken cancellationToken)
    {
        await _channel.ExchangeDeclareAsync(
            exchange: "product.created",
            type: ExchangeType.Fanout,
            durable: true, cancellationToken: cancellationToken);

    }

    public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
    
}