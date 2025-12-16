// <copyright file="IEventRouting"
//Author="tjtechy">
//EcommerceMicroservicesDotNet
//Copyright (C) TJTECHY
//</copyright>


namespace messaging.Interfaces;

public interface IEventRouting
{
    string GetDestinationForEvent<TEvent>();
}