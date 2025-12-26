using messaging.Contracts;

namespace messaging.Interfaces;

public interface IMessagePublisher
{
    Task PublishAsync<TMessage>(
        TMessage message,
        EventDestination destination,
        CancellationToken cancellationToken = default) where TMessage : class;
}