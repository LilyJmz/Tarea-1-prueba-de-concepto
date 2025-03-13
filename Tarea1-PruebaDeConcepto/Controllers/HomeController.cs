using Microsoft.AspNetCore.Mvc;

namespace Tarea1_PruebaDeConcepto.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("API is running!");
        }
    }
}

