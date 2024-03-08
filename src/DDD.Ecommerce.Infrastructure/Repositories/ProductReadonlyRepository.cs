using DDD.Ecommerce.Domain.Orders;
using DDD.Ecommerce.Infrastructure.Database.Context;
using System;
using System.Linq;

namespace DDD.Ecommerce.Infrastructure.Repositories
{
    public class ProductReadonlyRepository : IProductRepository
    {
        private readonly EcommerceContext _context;
        public ProductReadonlyRepository(EcommerceContext context)
        {
            _context = context;
        }

        public Product Get(Guid productId)
        {
            return _context.Products.First(x => x.Id == productId);
        }
    }
}
