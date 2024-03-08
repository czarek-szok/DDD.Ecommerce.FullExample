using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using DDD.Ecommerce.Core.Exceptions;

namespace DDD.Ecommerce.Core.Cqrs.Commands
{
    public class CommandDispatcher : ICommandDispatcher
    {
        private readonly IServiceProvider _serviceProvider;

        public CommandDispatcher(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task DispatchAsync<TCommand>(TCommand command, CancellationToken cancellationToken) where TCommand : ICommand
        {
            ICommandHandler<TCommand>? commandHandler = ResolveCommandHandler<TCommand>();

            await ValidateAsync(command, cancellationToken);

            await commandHandler.HandleAsync(command, cancellationToken);
        }

        public async Task<TResult> DispatchAsync<TCommand, TResult>(TCommand command, CancellationToken cancellationToken) where TCommand : ICommand<TResult>
        {
            ICommandHandler<TCommand, TResult>? commandHandler = ResolveCommandHandler<TCommand, TResult>();

            await ValidateAsync(command, cancellationToken);

            return await commandHandler.HandleAsync(command, cancellationToken);
        }

        private ICommandHandler<TCommand, TResult> ResolveCommandHandler<TCommand, TResult>() where TCommand : ICommand<TResult>
        {
            var commandHandler = _serviceProvider.GetService<ICommandHandler<TCommand, TResult>>();

            if (commandHandler == null)
            {
                throw new AdvisoryOnboardingException($"No command handler found for TCommand: {typeof(TCommand).Name}, TResult: {typeof(TResult).Name}");
            }

            return commandHandler;
        }

        private ICommandHandler<TCommand> ResolveCommandHandler<TCommand>() where TCommand : ICommand
        {
            var commandHandler = _serviceProvider.GetService<ICommandHandler<TCommand>>();

            if (commandHandler == null)
            {
                throw new ArgumentException($"No command handler found for TCommand: {typeof(TCommand).Name}");
            }

            return commandHandler;
        }


        private async Task ValidateAsync<TCommand>(TCommand command, CancellationToken cancellationToken) where TCommand : ICommand
        {
            var validator = _serviceProvider.GetService<IValidator<TCommand>>();

            if (validator != null)
            {
                var result = await validator.ValidateAsync(command, cancellationToken);

                if (!result.IsValid)
                {
                    throw new ValidationException(result.Errors);
                }
            }
        }
    }
}
