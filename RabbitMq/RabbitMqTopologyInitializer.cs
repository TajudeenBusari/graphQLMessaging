using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;

namespace messaging.RabbitMq;

public class RabbitMqTopologyInitializer : IHostedService
{
    private readonly IChannel _channel;

    public RabbitMqTopologyInitializer(IChannel channel)
    {
        _channel = channel;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        await _channel.ExchangeDeclareAsync(
            "product.exchange",
            ExchangeType.Fanout,
            true,
            cancellationToken: cancellationToken);
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}