using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using WebAPIConfiguration.Data;
using WebAPIConfiguration.Model;

namespace WebAPIConfiguration.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;
    private readonly NetLogContext _context;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, NetLogContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet(Name = "GetNetLogs")]
    public async Task<ActionResult<IList<NetLog>>> GetNetLogs()
    {
        return await _context.NetLogs.ToListAsync();
    }
}
