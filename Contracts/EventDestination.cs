namespace messaging.Contracts;

#pragma warning disable SA1313
public record EventDestination(string ExchangeOrTopic, string RoutingKeyOrSubject);
#pragma warning restore SA1313
