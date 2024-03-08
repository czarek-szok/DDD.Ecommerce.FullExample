﻿using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;
using DDD.Ecommerce.Core.Cqrs.Commands;
using DDD.Ecommerce.Core.Cqrs.Query;
using DDD.Ecommerce.Interfaces.Commands;
using DDD.Ecommerce.Interfaces.Queries.Orders;

namespace DDD.Ecommerce.Api.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class OrdersController : ControllerBase
    {
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly IQueryDispatcher _queryDispatcher;

        public OrdersController(
            ICommandDispatcher commandDispatcher,
            IQueryDispatcher queryDispatcher)
        {
            _commandDispatcher = commandDispatcher;
            _queryDispatcher = queryDispatcher;
        }

        [HttpPost("order")]
        public async Task CreateOrder([FromBody] CreateOrderCommand command, CancellationToken cancellationToken)
        {
            await _commandDispatcher.DispatchAsync(command, cancellationToken);
        }

        [HttpPost("order/product")]
        public async Task AddProductToOrder([FromBody] AddProductToOrderCommand command, CancellationToken cancellationToken)
        {
            await _commandDispatcher.DispatchAsync(command, cancellationToken);
        }

        [HttpPost("order/accept")]
        public async Task AcceptOrder([FromBody] AcceptOrderCommand command, CancellationToken cancellationToken)
        {
            await _commandDispatcher.DispatchAsync(command, cancellationToken);
        }

        [HttpGet]
        public async Task<GetOrdersQueryResult> GetOrders(CancellationToken cancellationToken)
        {
            return await _queryDispatcher.DispatchAsync(new GetOrdersQuery(), cancellationToken);
        }
    }

}
