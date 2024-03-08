using System;

namespace DDD.Ecommerce.Core.Services
{
    public class SystemTimeProvider : ISystemTime
    {
        public DateTime UtcNow => DateTime.UtcNow;
    }
}
