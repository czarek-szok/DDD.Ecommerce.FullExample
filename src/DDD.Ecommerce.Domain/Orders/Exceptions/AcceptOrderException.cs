using System;


namespace DDD.Ecommerce.Domain.Orders.Exceptions
{
    public class AcceptOrderException : Exception
    {
        public AcceptOrderException(Guid orderId, params string[] errorMessages)
        {

        }
    }
}
