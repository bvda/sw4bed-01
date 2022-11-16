using Microsoft.AspNetCore.Mvc;
using MTGCollection.Data;
using MTGCollection.Models;

namespace MTGCollection.API.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;
    private readonly CardService _cardService;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, CardService cardService)
    {
        _logger = logger;
        _cardService = cardService;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public async Task<IList<Card>> Get()
    {
        // _cardService.SeedCards();
        return await _cardService.GetAllCards();
    }
}
