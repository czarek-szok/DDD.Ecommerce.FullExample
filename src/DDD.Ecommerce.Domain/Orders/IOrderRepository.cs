using DDD.Ecommerce.Core.Repository;
using System;

namespace DDD.Ecommerce.Domain.Orders
{
    public interface IOrderRepository : IRepository<Order>
    {
    }
}
