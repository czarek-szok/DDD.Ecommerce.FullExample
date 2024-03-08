using DDD.Ecommerce.Core.Cqrs.Commands;
using System;

namespace DDD.Ecommerce.Interfaces.Commands
{
    public class AddProductToOrderCommand : ICommand
    {
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
}