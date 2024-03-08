using Microsoft.Extensions.DependencyInjection;
using DDD.Ecommerce.Core.Extensions;

namespace DDD.Ecommerce.Application
{
    public static class QueriesModule
    {
        public static void AddQueruModule(this IServiceCollection services)
        {
            var thisAssembly = typeof(QueriesModule).Assembly;

            services.AddQueryHandlers(thisAssembly);
        }
    }
}
