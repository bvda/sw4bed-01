using Microsoft.AspNetCore.Mvc;

namespace Testing.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;
    private readonly TemperatureConverter _converter;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, TemperatureConverter converter)
    {
        _logger = logger;
        _converter = converter;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateTime.Now.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }

    [HttpPost(Name = "PostCelsiusToFahrenheit")]
    public ActionResult Post(ConvertRequestData value) {
        try {
            return Ok(_converter.CelsiusToFahrenheit(value.Value));
        } catch (ArgumentOutOfRangeException e) {
            return BadRequest(e.Message);
        }
    }

    public class ConvertRequestData {
        public decimal Value {get; set;}
    } 
}
