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
    public ActionResult Get(int? index)
    {
        var items = _service.GetItems();
        if(index.HasValue) {
            if(index >= items.Count || index < 0) {
                return BadRequest();
            }
            return Ok(items[index.Value]);
        }
        return Ok(items);
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
