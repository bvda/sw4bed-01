using Microsoft.AspNetCore.Mvc;
using Lists.Services;

namespace Lists.Controllers;

[ApiController]
[Route("[controller]")]
public class ListController : ControllerBase
{
    private readonly ILogger<ListController> _logger;
    private readonly ListService _service;  

    public ListController(ILogger<ListController> logger, ListService service)
    {
        _logger = logger;
        _service = service;
    }

    [HttpGet(Name = "GetListController")]
    public ActionResult Get()
    {
        return Ok();
    }
}
