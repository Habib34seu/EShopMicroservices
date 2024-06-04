﻿
using BuildingBlocks.Messaging.Events;
using MassTransit;
using Ordering.Application.Dtos;
using Ordering.Application.Orders.Commands.CreateOrder;

namespace Ordering.Application.Orders.EventHandlers.Integration;

public class BusketCheckoutEventHandler
    (ISender sender, ILogger<BusketCheckoutEventHandler> logger)
    : IConsumer<BasketCheckoutEvent>
{
    public async Task Consume(ConsumeContext<BasketCheckoutEvent> context)
    {
        /*
         * Create a new order and start order fullfill procrss
         */

        logger.LogInformation("Integration Event handle: {IntegrationEvent}", context.Message.GetType().Name);

        var command = MapToCreateOrderCommand(context.Message);
        await sender.Send(command);
        
    }

    private CreateOrderCommand MapToCreateOrderCommand(BasketCheckoutEvent message)
    {
        var addressDto = new  AddressDto(
            message.FirstName,
            message.LastName,
            message.EmailAddress,
            message.AddressLine,
            message.Country,
            message.State,
            message.ZipCode);

        var paymenDto = new PaymentDto(
            message.CardName,
            message.CardNumber,
            message.Expiration,
            message.CVV,
            message.PaymentMethod);

        var orderId = Guid.NewGuid();

        var orderDto = new OrderDto(
            Id: orderId,
            CustomerId: message.CustomerId,
            OrderName: message.UserName,
            ShippingAddress: addressDto,
            BillingAddress: addressDto,
            Payment: paymenDto,
            Status: Ordering.Domain.Enums.OrderStatus.Pending,
            OrderItems:
            [
                new OrderItemDto(orderId, new Guid("5334C996-8457-4CF0-815C-ED2B77C4FF61"),2,500),
                new OrderItemDto(orderId, new Guid("C67D6323-E8B1-4BDF-9A75-B0D0D2E7E914"),1,400),
            ]);
        return new CreateOrderCommand(orderDto);
    }
}
