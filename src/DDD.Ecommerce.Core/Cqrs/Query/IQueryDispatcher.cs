using System.Threading;
using System.Threading.Tasks;

namespace DDD.Ecommerce.Core.Cqrs.Query
{
    public interface IQueryDispatcher
    {
        Task<TQueryResult> DispatchAsync<TQueryResult>(IQuery<TQueryResult> query, CancellationToken cancellationToken);
    }
}
