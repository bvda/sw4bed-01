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

    private readonly IConfiguration _configuration;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, NetLogContext context, IConfiguration configuration)
    {
        _logger = logger;
        _configuration = configuration;
        _context = context;
    }

    [HttpGet(Name = "GetNetLogs")]
    public async Task<ActionResult<IList<NetLog>>> GetNetLogs()
    {
        Console.WriteLine(_configuration["OverrideThisValue"]);
        Console.WriteLine(_configuration["Ests:Fest"]);
        return await _context.NetLogs.ToListAsync();
    }
}
