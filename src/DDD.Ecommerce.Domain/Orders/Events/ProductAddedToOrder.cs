
using System;

namespace DDD.Ecommerce.Domain.Orders.Events
{
    public class ProductAddedToOrder
    {
        public Guid OrderId { get; private set; }
        public Guid ProductId { get; private set; }

        public ProductAddedToOrder(Guid orderId, Guid productId)
        {
            OrderId = orderId;
            ProductId = productId;
        }
    }
}
