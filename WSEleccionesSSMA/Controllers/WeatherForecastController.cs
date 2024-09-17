using Microsoft.AspNetCore.Mvc;

namespace WSEleccionesSSMA.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                //TemperatureC = Random.Shared.Next(-20, 155),
                TemperatureC = 1,
                TemperatureF = 10,
                Summary = "Damon Savlatore"//Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}