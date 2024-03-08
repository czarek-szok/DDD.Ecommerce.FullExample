using DDD.Ecommerce.Core.Cqrs.Query;
using DDD.Ecommerce.Infrastructure.Database.Context;
using DDD.Ecommerce.Interfaces.Queries.Orders;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DDD.Ecommerce.Queries.QueryHandlers
{
    public class GetOrdersQueryHandler : IQueryHandler<GetOrdersQuery, GetOrdersQueryResult>
    {
        private readonly EcommerceContext _ecommerceContext;

        public GetOrdersQueryHandler(EcommerceContext ecommerceContext)
        {
            _ecommerceContext = ecommerceContext;
        }

        public async Task<GetOrdersQueryResult> HandleAsync(GetOrdersQuery query, CancellationToken cancellationToken)
        {
            var orders = await _ecommerceContext.Order
                .Select(x => new Order(x.Id, x.Status.ToString(), x.CreateDate))
                .ToListAsync();
            return new GetOrdersQueryResult(orders);
        }
    }
}
