using System.Threading.Tasks;

namespace DDD.Ecommerce.Core.Events.Publisher
{
    public class EventPublisher : IEventPublisher
    {
        public Task PublishAsync<TEvent>(TEvent evt) where TEvent : class, IEvent
        {
            return Task.CompletedTask;
        }
    }
}
