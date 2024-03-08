using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;
using DDD.Ecommerce.Core.Cqrs.Commands;
using DDD.Ecommerce.Core.Cqrs.Query;
using DDD.Ecommerce.Interfaces.Commands;

namespace DDD.Ecommerce.Api.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class InvoiceController : ControllerBase
    {
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly IQueryDispatcher _queryDispatcher;

        public InvoiceController(
            ICommandDispatcher commandDispatcher,
            IQueryDispatcher queryDispatcher)
        {
            _commandDispatcher = commandDispatcher;
            _queryDispatcher = queryDispatcher;
        }

        [HttpPost("invoice")]
        public async Task CreateOrder([FromBody] IssueInvoiceCommand command, CancellationToken cancellationToken)
        {
            await _commandDispatcher.DispatchAsync(command, cancellationToken);
        }
    }

}
