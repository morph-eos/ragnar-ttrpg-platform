using Microsoft.AspNetCore.Mvc;

namespace JuggleHiveWebapp.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AliveController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new { message = "Server is alive" });
        }
    }
}