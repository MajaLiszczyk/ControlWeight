using Microsoft.AspNetCore.Mvc;

namespace ControlWeightAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        private readonly IWeatherForecastService _service;
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherForecastService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var result = _service.Get();
            return result; 
        }

        [HttpGet("currentDay/{max}")]
        public IEnumerable<WeatherForecast> Get2([FromQuery] int take, [FromRoute] int max)
        {
            var result = _service.Get();
            return result;
        }

        [HttpPost]
        //public string Hello([FromBody] string name)

        //ActionResult<string>  - zwróci string oraz kod statusu
        public ActionResult<string> Hello([FromBody] string name)
        {
            // I sposób:
            // HttpContext.Response.StatusCode = 401;
            // return $"Hello {name}"; */
            
            // II sposob:
            //return StatusCode(401, $"Hello {name}");

            // III spsob:
            return NotFound($"Hello {name}");
        }
    }
}
