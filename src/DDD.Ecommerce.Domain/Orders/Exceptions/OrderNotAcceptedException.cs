using System;


namespace DDD.Ecommerce.Domain.Orders.Exceptions
{
    public class OrderNotAcceptedException : Exception
    {
        public OrderNotAcceptedException(Guid orderId, params string[] errorMessages) : base($"Order {orderId} not accepted ")
        {

        }
    }
}
