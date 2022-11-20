﻿using Genocs.Core.Demo.Contracts;
using Genocs.Core.Demo.Domain.Aggregates;
using Genocs.Core.Domain.Repositories;
using MassTransit;

namespace Genocs.Core.Demo.ServiceBusAzure.Service.Consumers;

public class SubmitOrderConsumer : IConsumer<SubmitOrder>
{
    private readonly ILogger<SubmitOrderConsumer> _logger;

    private readonly IRepository<Order, string> _orderRepository;

    public SubmitOrderConsumer(ILogger<SubmitOrderConsumer> logger, IRepository<Order, string> orderRepository)
    {
        _logger = logger ?? throw new System.ArgumentNullException(nameof(logger));
        _orderRepository = orderRepository ?? throw new System.ArgumentNullException(nameof(orderRepository));
    }

    public async Task Consume(ConsumeContext<SubmitOrder> context)
    {
        Order order = new Order(context.Message.OrderId, context.Message.UserId, "", 1, "EUR");
        await _orderRepository.InsertAsync(order);
        _logger.LogInformation($"Order {context.Message.OrderId} processed!");
    }
}