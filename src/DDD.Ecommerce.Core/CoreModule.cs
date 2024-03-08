using Microsoft.Extensions.DependencyInjection;
using DDD.Ecommerce.Core.Cqrs.Commands;
using DDD.Ecommerce.Core.Cqrs.Query;
using DDD.Ecommerce.Core.Events.Publisher;
using DDD.Ecommerce.Core.Services;

namespace DDD.Ecommerce.Application
{
    public static class CoreModule
    {
        public static void AddCoreModule(this IServiceCollection services)
        {
            services.AddSingleton<ISystemTime, SystemTimeProvider>();

            services.AddScoped<ICommandDispatcher, CommandDispatcher>();
            services.AddScoped<IQueryDispatcher, QueryDispatcher>();
            services.AddSingleton<IEventPublisher, EventPublisher>();
        }
    }
}
