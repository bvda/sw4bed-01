using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

using WebAPIConfiguration.Options;

namespace WebAPIConfiguration.Controllers;

[ApiController]
[Route("[controller]")]
public class ThemeController : Controller 
{
  private readonly AppShellOptions _options;

  public ThemeController(IOptionsSnapshot<AppShellOptions> configuration) {
    _options = configuration.Value;
  }

  [EnableCors("Theme")]
  [HttpGet]
  public IActionResult GetTheme()
  {
    return Json(_options);
  }
}