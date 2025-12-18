// <copyright file="IEventRouting"
//Author="tjtechy">
//EcommerceMicroservicesDotNet
//Copyright (C) TJTECHY
//</copyright>


using messaging.Contracts;

namespace messaging.Interfaces;

public interface IEventRouting
{
    //string GetDestinationForEvent<TEvent>();
    EventDestination GetDestinationForEvent<TEvent>();
}