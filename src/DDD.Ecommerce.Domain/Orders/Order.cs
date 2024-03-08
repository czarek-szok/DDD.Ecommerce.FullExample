
using DDD.Ecommerce.Core.Domain;
using DDD.Ecommerce.Application.Exceptions;
using DDD.Ecommerce.Domain.Orders.Events;
using DDD.Ecommerce.Domain.Orders.Exceptions;
using DDD.Ecommerce.Domain.Orders.Policies.Discount;
using DDD.Ecommerce.Domain.Orders.Specification;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DDD.Ecommerce.Domain.Orders
{
    public class Order : AggregateRoot
    {
        private IDiscountPolicy _discountPolicy;
        public ICollection<OrderLine> OrderLines { get; private set; }
        public OrderStatus Status { get; private set; }
        public DateTime CreateDate { get; private set; }
        public DateTime AcceptDate { get; private set; }
        public Customer Customer { get; private set; }

        public Order() { }
        public Order(Customer customer)
        {
            Customer = customer;
            Status = OrderStatus.Draft;
            OrderLines = new List<OrderLine>();
            CreateDate = DateTime.Now;
        }

        public void ApplyDiscount(IDiscountPolicy discountPolicy)
        {
            _discountPolicy = discountPolicy;
        }

        public void AddProduct(Product product, int quantity)
        {

            //TODO: Change the aggregate state by updating TotalPrice
            OrderLine orderLine = OrderLines.FirstOrDefault(x => x.Product != null && x.Product.Id.Equals(product.Id));

            if (orderLine == null)
            {
                var newOrderLine = new OrderLine(product, quantity, _discountPolicy);
                OrderLines.Add(newOrderLine);
               // Raise(new ProductAddedToOrder(Id, product.Id));
            }
            else
            {
                orderLine.IncreaseQuantity(quantity, _discountPolicy);
                //Raise(new ChangedProductQuantityInOrderEvent(Id, product.Id));
            }
        }

        public void Accept()
        {
            CheckIfOrderCanBeAccepted();

            Status = OrderStatus.Accepted;
            AcceptDate = DateTime.Now;
            Raise(new OrderAcceptedEvent(Id));
        }

        private void CheckIfOrderCanBeAccepted()
        {
            if (!Customer.IsVip)
            {
                if (IsOverdued())
                    throw new OverduedOrderException(Id);

                if (Customer.IsDebtor)
                {
                    throw new CustomerIsDebtorException(Customer.Id);
                }
            }

            //ALTERNATIVE WAY USING SPECIFICATION PATTERN
            //var specification = new CustomerIsNotVipSpecification()
            //  .And(new CustomerIsDebtorSpecification(customerOrders))
            //   .And(new OrderIsOverduedSpecification());

            //var result = specification.IsSatisfiedBy(this);
            //if (!result.IsSatisifed)
            //    throw new AcceptOrderException(Id, result.Errors.ToArray());
        }

        private bool IsOverdued()
        {
            return CreateDate < DateTime.Today.AddMonths(-1);
        }

        public bool IsAccepted()
        {
            return Status == OrderStatus.Accepted;
        }
    }
}
