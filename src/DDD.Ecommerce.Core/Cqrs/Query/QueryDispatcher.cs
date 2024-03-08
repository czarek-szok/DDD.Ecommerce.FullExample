using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;
using DDD.Ecommerce.Core.Exceptions;

namespace DDD.Ecommerce.Core.Cqrs.Query
{
    public class QueryDispatcher : IQueryDispatcher
    {
        private readonly IServiceProvider _serviceProvider;

        public QueryDispatcher(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<TQueryResult> DispatchAsync<TQueryResult>(IQuery<TQueryResult> query, CancellationToken cancellationToken)
        {
            dynamic queryHandler = ResolveQueryHandler(query);

            await ValidateAsync(query, cancellationToken);

            return await queryHandler.HandleAsync((dynamic)query, cancellationToken);
        }

        private dynamic ResolveQueryHandler<TQueryResult>(IQuery<TQueryResult> query)
        {
            var queryHandlerType = typeof(IQueryHandler<,>).MakeGenericType(query.GetType(), typeof(TQueryResult));

            dynamic? queryHandler = _serviceProvider.GetService(queryHandlerType);
            if (queryHandler == null)
            {
                throw new ArgumentException($"No query handler found for query: {query.GetType().Name}, TQueryResult: {typeof(TQueryResult).Name}");
            }

            return queryHandler;
        }

        private async Task ValidateAsync<TQuery>(TQuery query, CancellationToken cancellationToken)
        {
            if (query == null)
            {
                throw new AdvisoryOnboardingException("Query was null");
            }

            var validatorType = typeof(IValidator<>).MakeGenericType(query.GetType());
            var validator = _serviceProvider.GetService(validatorType);

            if (validator != null)
            {
                ValidationResult result = await ((dynamic)validator).ValidateAsync((dynamic)query, cancellationToken);

                if (!result.IsValid)
                {
                    throw new ValidationException(result.Errors);
                }
            }
            await Task.CompletedTask;
        }
    }
}
