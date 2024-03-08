using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Reflection;
using DDD.Ecommerce.Core.Cqrs.Commands;
using DDD.Ecommerce.Core.Cqrs.Query;

namespace DDD.Ecommerce.Core.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddCommandHandlers(this IServiceCollection services, Assembly assembly)
        {
            services.AddTypesImplementingGenericInterface(assembly, typeof(ICommandHandler<>), ServiceLifetime.Transient);
            services.AddTypesImplementingGenericInterface(assembly, typeof(ICommandHandler<,>), ServiceLifetime.Transient);
        }

        public static void AddQueryHandlers(this IServiceCollection services, Assembly assembly)
        {
            services.AddTypesImplementingGenericInterface(assembly, typeof(IQueryHandler<,>), ServiceLifetime.Transient);
        }

        public static void AddFluentValidators(this IServiceCollection services, Assembly assembly)
        {
            services.AddTypesImplementingGenericInterface(assembly, typeof(IValidator<>), ServiceLifetime.Singleton);
        }


        public static void AddTypesImplementingGenericInterface(this IServiceCollection services, Assembly assembly, Type genericInterface, ServiceLifetime serviceLifetime)
        {
            foreach (var type in assembly.DefinedTypes.Where(t => t.IsAssignableToGenericInterface(genericInterface) && !t.IsAbstract))
            {
                var interfaceType = type.GetImplementedGenericInterfaceType(genericInterface);
                services.Add(new ServiceDescriptor(interfaceType!, type, serviceLifetime));
            }
        }
    }
}
