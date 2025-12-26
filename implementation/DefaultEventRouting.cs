using messaging.Contracts;
using messaging.Interfaces;

namespace messaging.implementation;

public class DefaultEventRouting : IEventRouting
{
    public EventDestination GetDestinationForEvent<TEvent>()
    {
        return typeof(TEvent).Name switch
        {
            nameof(ProductCreatedEvent) => new EventDestination("product.exchange", "product.created"),

            //Add more event types and their destinations here: e.g., ProductUpdatedEvent, OrderPlacedEvent, etc.
            nameof(ProductUpdatedEvent) => new EventDestination("product.exchange", "product.updated"),
            nameof(ProductDeletedEvent) => new EventDestination("product.exchange", "product.deleted"),
            _ => throw new ArgumentException($"No destination configured for event type {typeof(TEvent).FullName}")
        };
    }
}