using System;
using System.Collections.Generic;
using DDD.Ecommerce.Core.Events;

namespace DDD.Ecommerce.Core.Domain
{
    public class AggregateRoot : IAggregateRoot
    {
        private readonly IList<IEvent> _events = new List<IEvent>();
        public IReadOnlyCollection<IEvent> Events => (IReadOnlyCollection<IEvent>)_events;

        public AggregateRoot()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; private set; }

        protected void Raise(IEvent eventItem)
        {
            _events.Add(eventItem);
        }

        void IAggregateRoot.ClearEvents()
        {
            _events.Clear();
        }
    }
}
