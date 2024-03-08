using DDD.Ecommerce.Core.Cqrs.Commands;
using System;

namespace DDD.Ecommerce.Interfaces.Commands
{
    public class CreateOrderCommand : ICommand
    {
        public Guid CustomerId { get; set; }
    }
}
