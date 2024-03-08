using DDD.Ecommerce.Core.Cqrs.Commands;
using System;

namespace DDD.Ecommerce.Interfaces.Commands
{
    public class AcceptOrderCommand : ICommand
    {
        public Guid OrderId { get; set; }
    }
}
