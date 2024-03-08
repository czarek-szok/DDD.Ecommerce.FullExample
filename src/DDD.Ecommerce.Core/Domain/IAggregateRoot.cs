using System.Collections.Generic;
using DDD.Ecommerce.Core.Events;

namespace DDD.Ecommerce.Core.Domain
{
    public interface IAggregateRoot
    {
        public IReadOnlyCollection<IEvent> Events { get; }

        public void ClearEvents();
    }
}
