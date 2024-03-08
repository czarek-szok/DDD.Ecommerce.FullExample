using DDD.Ecommerce.Core.Cqrs.Commands;
using DDD.Ecommerce.Interfaces.Commands;
using DDD.Ecommerce.Domain.Orders;
using System.Threading.Tasks;
using System.Threading;

namespace DDD.Ecommerce.Application.CommandHandlers
{
    public class AcceptOrderCommandHandler : ICommandHandler<AcceptOrderCommand>
    {
        private readonly IOrderRepository _orderRepository;

        public AcceptOrderCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task HandleAsync(AcceptOrderCommand command, CancellationToken cancellationToken)
        {

                var order = await _orderRepository.GetAsync(command.OrderId, cancellationToken);

            order.Accept();

            await _orderRepository.UpdateAsync(order, cancellationToken);
        }
    }
}