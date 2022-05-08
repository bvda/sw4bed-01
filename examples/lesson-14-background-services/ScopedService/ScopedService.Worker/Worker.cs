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
        var api = scope.ServiceProvider.GetRequiredService<CurrencyService>();
        var db = scope.ServiceProvider.GetRequiredService<ExchangeDbContext>();
        var result = await api.GetRandomCurrency();
        if (result is not null) {
          await db.AddAsync(result);
          await db.SaveChangesAsync();
        }
      }
      _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
      await Task.Delay(1000, stoppingToken);
    }
  }
}
