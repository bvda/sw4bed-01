using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using Quartz.Data;

namespace Quartz.API.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly ILogger<WeatherForecastController> _logger;
    private readonly RandomNumberDbContext _context;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, RandomNumberDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public async Task<ActionResult<IEnumerable<RandomNumber>>> Get()
    {
        return await _context.Numbers.ToListAsync();
    }
}
