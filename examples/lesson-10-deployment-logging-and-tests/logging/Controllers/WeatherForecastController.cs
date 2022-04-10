using Microsoft.AspNetCore.Mvc;

namespace logging.Controllers;

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

    [Route("")]
    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        var result = Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateTime.Now.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
        _logger.LogInformation("Forecast {@forecast}", result);
        return result;
    }
    
    [Route("error")]
    [HttpGet(Name = "GetWeatherForecastError")]
    public void GetError()
    {
        _logger.LogError("GetWeatherForecastError");
        throw new Exception("GetWeatherForecastError");
    }
    
    [Route("warning")]
    [HttpGet(Name = "GetWeatherForecastWarning")]
    public ActionResult GetWarning()
    {
        _logger.LogWarning("GetWeatherForecastWarning");
        return BadRequest("BadRequest");
    }
}
