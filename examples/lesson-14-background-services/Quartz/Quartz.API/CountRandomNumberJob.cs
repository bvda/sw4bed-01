using Quartz.Data;

namespace Quartz.API;

public class CountRandomNumberJob : IJob 
{
  private readonly ILogger<CountRandomNumberJob> _logger;
  private readonly RandomNumberDbContext _dbContext;

  public CountRandomNumberJob(ILogger<CountRandomNumberJob> logger, RandomNumberDbContext dbContext) 
  {
    _dbContext = dbContext;
    _logger = logger;
  }

  public Task Execute(IJobExecutionContext context)
  {
    var count = _dbContext.Numbers.Count();
    _logger.LogInformation($"{count}");
    return Task.FromResult(count);
  }
}