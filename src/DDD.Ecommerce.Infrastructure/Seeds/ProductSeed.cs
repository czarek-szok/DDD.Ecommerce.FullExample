using DDD.Ecommerce.Domain.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Ecommerce.Infrastructure.Seeds
{
    public static class ProductSeed
    {
        public static Product[] CreateProducts()
        {
            return new[]
            {
                new Product(new Guid("1454e2a5-1f32-4e27-9bb5-bc1faffbed73"), 100, ProductType.Phone),
                 new Product(new Guid("5b16592b-dd94-43ef-a2af-2ddc3bd640fd"), 50, ProductType.Audio)
            };
        }
    }
}
