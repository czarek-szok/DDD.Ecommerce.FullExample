using System.Threading.Tasks;

namespace DDD.Ecommerce.Core.Events.Publisher
{
    public interface IEventPublisher
    {
        Task PublishAsync<TEvent>(TEvent evt) where TEvent : class, IEvent;
    }
}
