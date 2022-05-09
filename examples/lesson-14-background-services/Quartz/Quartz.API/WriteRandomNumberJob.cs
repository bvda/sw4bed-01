using Quartz.Data;

namespace Quartz.API;

public class WriteRandomNumberJob : IJob
{
  private readonly ILogger<WriteRandomNumberJob> _logger;
  private readonly RandomNumberDbContext _dbContext;

  public WriteRandomNumberJob(ILogger<WriteRandomNumberJob> logger, RandomNumberDbContext dbContext) 
  {
    _dbContext = dbContext;
    _logger = logger;
  }

  public async Task Execute(IJobExecutionContext context)
  {
    await _dbContext.AddAsync(new RandomNumber {
      Number = new Random().Next()
    });
    await _dbContext.SaveChangesAsync();
  }
}