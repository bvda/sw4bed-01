using Microsoft.AspNetCore.Mvc;
using Lists.Services;
using Lists.Models;

namespace Lists.Controllers;

[ApiController]
[Route("[controller]")]
public class ListController : ControllerBase
{
    private readonly ILogger<ListController> _logger;
    private readonly ListService<string> _service;  

    public ListController(ILogger<ListController> logger, ListService<string> service)
    {
        _logger = logger;
        _service = service;
    }

    [HttpGet]
    public ActionResult<List<ListItem<string>>> Get()
    {
        return _service.GetItems();
    }

    [HttpPost]
    public ActionResult<List<ListItem<string>>> Post(ListItem<string> item) {
        return _service.AddItemToList(item);
    }

    [Route("{index}")]
    [HttpDelete]
    public ActionResult<List<ListItem<string>>> DeleteByIndex(int index) {
        return _service.RemoveItem(index);
    }

}
