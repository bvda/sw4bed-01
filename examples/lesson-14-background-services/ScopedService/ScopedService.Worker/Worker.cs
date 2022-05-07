using ScopedService.Data;

namespace ScopedService.Worker;

public class Worker : BackgroundService
{
  private readonly ILogger<Worker> _logger;
  private readonly IServiceProvider _provider;

  public Worker(ILogger<Worker> logger, IServiceProvider provider)
  {
    _logger = logger;
    _provider = provider;
  }

  protected override async Task ExecuteAsync(CancellationToken stoppingToken)
  {
    while (!stoppingToken.IsCancellationRequested)
    {
      using (var scope = _provider.CreateScope())
      {
        var context = scope.ServiceProvider.GetRequiredService<CurrencyService>();
        // _logger.LogInformation(context.Currencies.AsEnumerable().ElementAt(new Random().Next(3)).Name);
      }
      _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
      await Task.Delay(1000, stoppingToken);
    }
  }
}
