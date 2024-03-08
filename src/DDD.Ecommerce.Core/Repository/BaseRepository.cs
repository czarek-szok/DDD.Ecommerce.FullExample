using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DDD.Ecommerce.Core.Domain;
using DDD.Ecommerce.Core.Domain.Exception;
using DDD.Ecommerce.Core.Events.Publisher;
using DDD.Ecommerce.Core.Services;

namespace DDD.Ecommerce.Core.Repository
{
    public abstract class BaseRepository<T> : IRepository<T> where T : class
    {
        private readonly DbContext _context;
        private readonly IEventPublisher _eventPublisher;

        protected BaseRepository(DbContext context, IEventPublisher eventPublisher)
        {
            _context = context;
            _eventPublisher = eventPublisher;
        }

        public virtual async Task<T> GetAsync(object id, CancellationToken cancellationToken)
        {
            var result = await _context.Set<T>().FindAsync(new[] { id }, cancellationToken);

            if (result == null)
                throw new ResourceNotFoundException($"An object with Id: {id} was not found in collection of {typeof(T)}");

            return result;
        }

        public virtual async Task<T?> FindAsync(object id, CancellationToken cancellationToken)
        {
            var result = await _context.Set<T>().FindAsync(new[] { id }, cancellationToken);
            return result;
        }

        public virtual async Task CreateAsync(T entity, CancellationToken cancellationToken)
        {
            _context.Add(entity);

            await SaveChangesAsync(cancellationToken);
            await PublishEvents(entity);
        }

        public virtual async Task UpdateAsync(T entity, CancellationToken cancellationToken)
        {
            await SaveChangesAsync(cancellationToken);
            await PublishEvents(entity);
        }

        public virtual async Task DeleteAsync(T entity, CancellationToken cancellationToken)
        {
            _context.Remove(entity);
            await SaveChangesAsync(cancellationToken);
        }

        public virtual async Task DeleteRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken)
        {
            _context.RemoveRange(entities);
            await SaveChangesAsync(cancellationToken);
        }

        private async Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }

        private async Task PublishEvents(T entity)
        {
            if (entity is IAggregateRoot aggregateRoot)
            {
                foreach (var evt in aggregateRoot.Events)
                {
                    await _eventPublisher.PublishAsync((dynamic)evt);
                }

                aggregateRoot.ClearEvents();
            }
        }
    }
}
