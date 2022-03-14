using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

using WebAPIConfiguration.Options;

namespace WebAPIConfiguration.Controllers;

[ApiController]
[Route("[controller]")]
public class ThemeController : Controller 
{
  private readonly ILogger<ThemeController> _logger;
  private readonly IOptions<AppShellOptions> _configuration;

  public ThemeController(ILogger<ThemeController> logger, IOptions<AppShellOptions> configuration) {
    _configuration = configuration;
    _logger = logger;
  }

  [HttpGet]
  public IActionResult GetTheme()
  {
    return Json(_configuration);
  }
}