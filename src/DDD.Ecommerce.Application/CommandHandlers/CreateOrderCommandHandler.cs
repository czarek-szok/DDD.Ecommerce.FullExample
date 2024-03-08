using DDD.Ecommerce.Core.Cqrs.Commands;
using DDD.Ecommerce.Domain.Orders;
using DDD.Ecommerce.Interfaces.Commands;
using System.Threading;
using System.Threading.Tasks;

namespace DDD.Ecommerce.Application.CommandHandlers
{
    public class CreateOrderCommandHandler : ICommandHandler<CreateOrderCommand>
    {
        private readonly IOrderFactory _orderFactory;
        private readonly IOrderRepository _orderRepository;

        public CreateOrderCommandHandler(IOrderFactory orderFactory,
                                         IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
            _orderFactory = orderFactory;
        }

        public async Task HandleAsync(CreateOrderCommand command, CancellationToken cancellationToken)
        {
            //get customer from external service :D
            var customer = new Customer(false, false, false);

            var order = _orderFactory.Create(customer);

            await _orderRepository.CreateAsync(order, cancellationToken);
        }
    }
}
