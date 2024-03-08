using System;

namespace DDD.Ecommerce.Domain.Orders
{
    public interface IProductRepository
    {
        Product Get(Guid productId);
    }
}
