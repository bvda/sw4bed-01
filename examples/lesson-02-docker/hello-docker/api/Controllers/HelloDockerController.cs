using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[ApiController]
[Route("")]
public class HelloDockerController : ControllerBase
{
    private readonly ILogger<HelloDockerController> _logger;

    public HelloDockerController(ILogger<HelloDockerController> logger)
    {
        _logger = logger;
    }

    [HttpGet("{name}", Name = "GetHelloDocker")]
    public Greeting Get(string name)
    {
        return new Greeting {
            Date = DateTime.Now,
            Message = $"Hello, {name}, how are you doing?"
        };
    }
}
