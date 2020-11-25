using Microsoft.AspNetCore.Mvc;

namespace Actio.Api.Controllers
{
    [ApiController]
    [Route("")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get() => Content("Hello from Actio API");
    }
}
