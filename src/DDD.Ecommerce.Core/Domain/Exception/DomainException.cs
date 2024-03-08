using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace DDD.Ecommerce.Core.Domain.Exception
{
    public abstract class DomainException : System.Exception
    {
        public IEnumerable<DomainExceptionMessage> ExceptionMessages { get; }

        protected DomainException()
        {
            ExceptionMessages = new[]
            {
                new DomainExceptionMessage(GetType().Name, Array.Empty<object>())
            };
        }

        protected DomainException(string errorMessage, params object[] args)
            : base(string.Format(errorMessage, args))
        {
            ExceptionMessages = new[]
            {
                new DomainExceptionMessage(errorMessage, args)
            };
        }

        protected DomainException(string errorMessage)
            : base(errorMessage)
        {
            ExceptionMessages = new[]
            {
                new DomainExceptionMessage(errorMessage)
            };
        }

        protected DomainException(IEnumerable<DomainExceptionMessage> exceptionMessages)
            : base(string.Join(';', exceptionMessages.Select(m => string.Format(m.Message, m.Arguments ?? Array.Empty<object>()))))
        {
            ExceptionMessages = exceptionMessages;
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
        }
    }
}
