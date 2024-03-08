using System.Threading;
using System.Threading.Tasks;

namespace DDD.Ecommerce.Core.Cqrs.Query
{
    public interface IQueryHandler<TQuery, TQueryResult> where TQuery : IQuery<TQueryResult>
    {
        Task<TQueryResult> HandleAsync(TQuery query, CancellationToken cancellationToken);
    }
}
