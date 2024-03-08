using System.Threading;
using System.Threading.Tasks;

namespace DDD.Ecommerce.Core.Cqrs.Commands
{
    public interface ICommandDispatcher
    {
        Task DispatchAsync<TCommand>(TCommand command, CancellationToken cancellationToken) where TCommand : ICommand;
        Task<TResult> DispatchAsync<TCommand, TResult>(TCommand command, CancellationToken cancellationToken) where TCommand : ICommand<TResult>;
    }
}
