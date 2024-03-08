using DDD.Ecommerce.Core.Cqrs.Commands;
using DDD.Ecommerce.Domain.Orders;
using DDD.Ecommerce.Domain.Orders.Policies.Discount;
using DDD.Ecommerce.Interfaces.Commands;
using System.Threading;
using System.Threading.Tasks;

namespace DDD.Ecommerce.Application.CommandHandlers
{
    public class AddProductToOrderCommandHandler : ICommandHandler<AddProductToOrderCommand>
    {
        private readonly IDiscountPolicyFactory _discountPolicyFactory;
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;

        public AddProductToOrderCommandHandler(IDiscountPolicyFactory discountPolicyFactory,
                                               IOrderRepository orderRepository,
                                               IProductRepository productRepository)
        {
            _discountPolicyFactory = discountPolicyFactory;
            _orderRepository = orderRepository;
            _productRepository = productRepository;
        }

        public async Task HandleAsync(AddProductToOrderCommand command, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetAsync(command.OrderId, cancellationToken);
            var product = _productRepository.Get(command.ProductId);
            var discount = _discountPolicyFactory.Create(order.Customer);

            order.ApplyDiscount(discount);
            order.AddProduct(product, command.Quantity);

            await _orderRepository.UpdateAsync(order, cancellationToken);
        }
    }
}
