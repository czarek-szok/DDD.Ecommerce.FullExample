using System;
using System.Linq;

namespace DDD.Ecommerce.Core.Extensions
{
    public static class TypeExtensions
    {
        public static bool IsAssignableToGenericInterface(this Type type, Type genericInterface)
        {
            return type.GetInterfaces().Where(i => i.IsGenericType)
                   .Any(i => i.GetGenericTypeDefinition() == genericInterface);

        }

        public static Type? GetImplementedGenericInterfaceType(this Type type, Type genericInterface)
        {
            //If Foo implements IBar<bool> then typeof(Foo).GetImplementedGenericInterfaceType(typeof(IFoo<>)) will return IFoo<bool>

            return type.GetInterfaces().Where(i => i.IsGenericType)
                   .SingleOrDefault(i => i.GetGenericTypeDefinition() == genericInterface);

        }
    }
}
