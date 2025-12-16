// <copyright file="RabbitMQOptions"
//Author="tjtechy">
//EcommerceMicroservicesDotNet
//Copyright (C) TJTECHY
//</copyright>


namespace messaging.Configuration;

// ReSharper disable once InconsistentNaming
public class RabbitMQOptions
{
    //these properties can dynamically be set in docker compose or kubernetes config maps or secrets by
    //using the same keys as defined in appsettings.json. e.g.,: RabbitMQ__HostName, RabbitMQ__Port etc.
    public string HostName { get; init; } = "localhost";
    public int Port { get; init; } = 5672;
    public string UserName { get; init; } = "guest";
    public string Password { get; init; } = "guest";
    
}