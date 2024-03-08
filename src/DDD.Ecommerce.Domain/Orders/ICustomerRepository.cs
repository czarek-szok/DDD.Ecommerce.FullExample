using System;

namespace DDD.Ecommerce.Domain.Orders
{
    public interface ICustomerRepository
    {
        Customer Get(Guid customerId);
        CustomerOrders GetOrders(Guid customerId);
    }
}
