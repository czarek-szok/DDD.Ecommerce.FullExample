using DDD.Ecommerce.Core.Events.Publisher;
using DDD.Ecommerce.Core.Repository;
using DDD.Ecommerce.Domain.Orders;
using DDD.Ecommerce.Infrastructure.Database.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DDD.Ecommerce.Infrastructure.Repositories
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        private readonly EcommerceContext _context;
        public OrderRepository(EcommerceContext context, IEventPublisher eventPublisher)
            : base(context, eventPublisher)
        {
            _context = context;
        }

        public override async Task<Order> GetAsync(object id, CancellationToken cancellationToken)
        {
            return await _context.Order
                .Include(x => x.Customer)
                .Include(x => x.OrderLines)
                .ThenInclude(y => y.Product)
                .FirstAsync(x => x.Id.ToString() == id.ToString(), cancellationToken);
        }
    }
}
