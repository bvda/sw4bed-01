using Microsoft.AspNetCore.Mvc;

using JobsAndModels.Models;

namespace JobsAndModels.Controllers;

[ApiController]
[Route("[controller]")]
public class JobController : ControllerBase
{
    private readonly ILogger<JobController> _logger;

    public JobController(ILogger<JobController> logger)
    {
        _logger = logger;
    }

    [HttpGet(nameof(Get))]
    public IEnumerable<Job> Get()
    {
        return null;
    }
}
