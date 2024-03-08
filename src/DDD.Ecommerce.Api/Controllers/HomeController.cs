using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DDD.Ecommerce.Api.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    [ApiVersion("1.1")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        [AllowAnonymous]
        public string Get()
        {
            const string welcomeMessage = "Welcome to DDD.Ecommerce.Api";
            return welcomeMessage;
        }
    }
}
