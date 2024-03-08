
using DDD.Ecommerce.Core.Events;
using System;

namespace DDD.Ecommerce.Domain.Orders.Events
{
    public class OrderAcceptedEvent : IEvent
    {
        public Guid OrderId { get; private set; }
        public OrderAcceptedEvent(Guid orderId)
        {
            OrderId = orderId;
        }
    }
}
