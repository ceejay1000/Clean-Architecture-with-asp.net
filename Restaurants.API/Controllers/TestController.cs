using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Restaurants.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ObjectResult Hello([FromHeader] object opts)
        {
            Console.WriteLine(opts.ToString());
            ValidationProblem();
            return StatusCode(200, "");
        }
    }
}
