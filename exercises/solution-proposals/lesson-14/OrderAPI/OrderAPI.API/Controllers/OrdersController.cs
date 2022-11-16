using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace OrderAPI.API.Controllers;

[ApiController]
[Route("[controller]")]
public class OrdersController : ControllerBase
{
    private readonly ILogger<OrdersController> _logger;
    private readonly IOrderService _service;

    public OrdersController(ILogger<OrdersController> logger, IOrderService service)
    {
        _logger = logger;
        _service = service;
    }

    [HttpGet(Name = "GetOrders")]
    public async Task<ActionResult<List<Order>>> Get()
    {
      return await _service.GetOrders();
    }

    [HttpPost(Name = "PostOrder")]
    public void Post(Order order)
    {
      _service.CreateOrder(order);
    }
}
