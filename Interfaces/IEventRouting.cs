using messaging.Contracts;

namespace messaging.Interfaces;

public interface IEventRouting
{
    //string GetDestinationForEvent<TEvent>();
    EventDestination GetDestinationForEvent<TEvent>();
}