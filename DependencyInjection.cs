// <copyright file="DependencyInjection"
//Author="tjtechy">
//EcommerceMicroservicesDotNet
//Copyright (C) TJTECHY
//</copyright>


using messaging.Configuration;
using messaging.implementation;
using messaging.Interfaces;
using messaging.RabbitMq;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;

namespace messaging;

public static class DependencyInjection
{
    public static IServiceCollection AddRabbitMqMessaging(
        this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<RabbitMQOptions>(
            configuration.GetSection("RabbitMQ"));
        services.AddSingleton<IConnection>(sp =>
        {
            var options = sp.GetRequiredService<IOptions<RabbitMQOptions>>().Value;
            var factory = new ConnectionFactory
            {
                HostName = options.HostName,
                Port = options.Port,
                UserName = options.UserName,
                Password = options.Password
            };
            return factory.CreateConnectionAsync()
                .GetAwaiter()
                .GetResult();
        });

        services.AddSingleton<IChannel>(sp =>
        {
            var connection = sp.GetRequiredService<IConnection>();
            return connection.CreateChannelAsync()
                .GetAwaiter()
                .GetResult();
        });
        //Register other messaging services like IMessagePublisher, IEventPublisher, IEventRouting etc.
        services.AddSingleton<IMessagePublisher, RabbitMqPublisher>();
        services.AddSingleton<IEventPublisher, EventPublisher>();
        services.AddSingleton<IEventRouting, DefaultEventRouting>();
        
        // You can register more messaging related services here as needed.
        services.AddHostedService<RabbitMqTopologyInitializer>();
        
        // Return the modified service collection
        return services;
    }
}