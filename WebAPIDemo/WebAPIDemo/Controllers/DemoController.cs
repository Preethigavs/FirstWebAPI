using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPIDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DemoController : ControllerBase
    {
        [HttpPost("demo/Sum")]
        public int Sum(int x, int y)
        {
            return x + y +100;
        }
    }
}
