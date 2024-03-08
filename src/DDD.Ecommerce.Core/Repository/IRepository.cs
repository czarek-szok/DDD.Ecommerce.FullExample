using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DDD.Ecommerce.Core.Repository
{
    public interface IRepository
    {
    }

    public interface IRepository<T> : IRepository
    {
        /// <summary>
        /// Gets entity by id. Throws exception if not found.
        /// </summary>
        /// <returns></returns>
        Task<T> GetAsync(object id, CancellationToken cancellationToken);

        /// <summary>
        /// Finds entity by id. Returns null if not found.
        /// </summary>
        /// <returns></returns>
        Task<T?> FindAsync(object id, CancellationToken cancellationToken);

        Task CreateAsync(T entity, CancellationToken cancellationToken);
        Task UpdateAsync(T entity, CancellationToken cancellationToken);
        Task DeleteAsync(T entity, CancellationToken cancellationToken);
        Task DeleteRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken);
    }
}
