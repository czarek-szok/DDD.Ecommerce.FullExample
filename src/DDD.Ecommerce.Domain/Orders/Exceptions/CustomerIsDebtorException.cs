using System;

namespace DDD.Ecommerce.Application.Exceptions
{
    public class CustomerIsDebtorException : Exception
    {
        public CustomerIsDebtorException(Guid customerId)
        {

        }
    }
}
