using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HelloCompose.Data;

namespace HelloCompose.API.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly ILogger<WeatherForecastController> _logger;
    private readonly WeatherForecastDbContext _context;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, WeatherForecastDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<WeatherForecast>>> Get()
    {
        return await _context.WeatherForecasts.ToListAsync();
    }

    
    [HttpGet("{id}")]
    public async Task<ActionResult<WeatherForecast>> GetWeatherForecast(long id)
    {
        var todoItem = await _context.WeatherForecasts.FindAsync(id);

        if (todoItem == null)
        {
            return NotFound();
        }

        return todoItem;
    }

    [HttpPost]
    public async Task<ActionResult<WeatherForecast>> PostWeatherForecast(WeatherForecast weatherForecast) 
    {
        _context.WeatherForecasts.Add(weatherForecast);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetWeatherForecast), new { id = weatherForecast.Id }, weatherForecast);
    }
}
