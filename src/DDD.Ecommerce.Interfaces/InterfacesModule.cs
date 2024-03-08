using Microsoft.Extensions.DependencyInjection;
using DDD.Ecommerce.Core.Extensions;

namespace DDD.Ecommerce.Application
{
    public static class InterfacesModule
    {
        public static void AddInterfacesModule(this IServiceCollection services)
        {
            var thisAssembly = typeof(InterfacesModule).Assembly;

            services.AddFluentValidators(thisAssembly);
        }
    }
}
