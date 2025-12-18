// <copyright file="CLASS"
//Author="tjtechy">
//EcommerceMicroservicesDotNet
//Copyright (C) TJTECHY
//</copyright>

namespace messaging.Contracts;

public record EventDestination(string ExchangeOrTopic, string RoutingKeyOrSubject);