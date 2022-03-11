using Microsoft.AspNetCore.Mvc;

using WebAPIConfiguration.Options;

namespace WebAPIConfiguration.Controllers;

[ApiController]
[Route("[controller]")]
public class ThemeController : Controller 
{
  private readonly ILogger<ThemeController> _logger;
  private readonly IConfiguration _configuration;

  public ThemeController(ILogger<ThemeController> logger, IConfiguration configuration) {
    _configuration = configuration;
    _logger = logger;
  }

  [HttpGet]
  public IActionResult GetTheme()
  {
    var appShellOptions = new AppShellOptions();
    _configuration.Bind(appShellOptions);

    return Json(appShellOptions);
  }
}