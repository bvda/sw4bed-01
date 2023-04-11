using Microsoft.AspNetCore.Mvc;
using Lists.Services;
using Lists.Models;

namespace Lists.Controllers;

[ApiController]
[Route("[controller]")]
public class ListController : ControllerBase
{
    private readonly ILogger<ListController> _logger;

    public ListController(ILogger<ListController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public ActionResult<List<ListItem<string>>> Get()
    {
        throw new NotImplementedException();
    }

    [HttpPost]
    public ActionResult<List<ListItem<string>>> Post(ListItem<string> item) {
        throw new NotImplementedException();
    }

    [Route("{index}")]
    [HttpDelete]
    public ActionResult<List<ListItem<string>>> DeleteByIndex(int index) {
        throw new NotImplementedException();
    }

}
