
using System;

namespace DDD.Ecommerce.Domain.Orders.Events
{
    public class ChangedProductQuantityInOrderEvent
    {
        public Guid OrderId { get; private set; }
        public Guid ProductId { get; private set; }

        public ChangedProductQuantityInOrderEvent(Guid orderId, Guid productId)
        {
            OrderId = orderId;
            ProductId = productId;
        }
    }
}
