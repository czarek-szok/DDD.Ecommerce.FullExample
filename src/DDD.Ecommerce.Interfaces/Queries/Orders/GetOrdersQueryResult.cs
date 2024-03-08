using System;
using System.Collections.Generic;

namespace DDD.Ecommerce.Interfaces.Queries.Orders
{
    public class GetOrdersQueryResult
    {
        public IList<Order> Orders { get; set; }

        public GetOrdersQueryResult(IList<Order> orders)
        {
            Orders = orders;
        }
    }

    public class Order
    {
        public Guid Id { get; set; }
        public string Status { get; set; }
        public DateTime CreateDate { get; set; }

        public Order(Guid id, string status, DateTime createDate)
        {
            Id = id;
            Status = status;
            CreateDate = createDate;
        }
    }
}
