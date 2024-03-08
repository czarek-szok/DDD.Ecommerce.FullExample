using System;

namespace DDD.Ecommerce.Application.Exceptions
{
    public class OverduedOrderException : Exception
    {
        public OverduedOrderException(Guid orderId)
        {

        }
    }
}
