using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPIDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {

        // api/Calculator/Add?x=50&y=50
       
        [HttpGet("Calculator/Add")] // if u giving unique name  then give /new name
        
        public int Add(int x, int y)
        {
            return x + y;
        }
       // api/Calculator/Subtract? x = 500 & y = 50
       [HttpPost("/Sum")]
        public int Sum(int x, int y)
        {
            return x + y;
        }
        // api/Calculator/Multiply?x=50&y=50
        [HttpPut]
        public int Multiply(int x, int y)
        {
            return x * y;
        }
        // api/Calculator/Divide?x=100&y=50
        [HttpDelete]
        public int Divide(int x, int y)
        {
            return x / y;
        }


    }
}
