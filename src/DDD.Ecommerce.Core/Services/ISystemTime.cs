using System;

namespace DDD.Ecommerce.Core.Services
{
    public interface ISystemTime
    {
        DateTime UtcNow { get; }
    }
}
