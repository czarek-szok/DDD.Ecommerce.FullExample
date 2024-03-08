using System.Threading;
using System.Threading.Tasks;

namespace DDD.Ecommerce.Core.Cqrs.Commands
{
    public interface ICommandHandler<in TCommand> where TCommand : ICommand
    {
        Task HandleAsync(TCommand command, CancellationToken cancellationToken);
    }

    public interface ICommandHandler<in TCommand, TResult> where TCommand : ICommand<TResult>
    {
        Task<TResult> HandleAsync(TCommand command, CancellationToken cancellationToken);
    }
}
