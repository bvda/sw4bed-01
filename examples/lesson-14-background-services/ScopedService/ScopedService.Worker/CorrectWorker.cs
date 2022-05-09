using ScopedService.Data;

namespace ScopedService.Worker;

public class CorrectWorker : BackgroundService
{
  private readonly ILogger<CorrectWorker> _logger;
  private readonly ICurrencyServiceFactory _factory;
  private readonly IServiceProvider _provider;

  public CorrectWorker(ILogger<CorrectWorker> logger, IServiceProvider provider, ICurrencyServiceFactory factory)
  {
    _logger = logger;
    _provider = provider;
    _factory = factory;
  }

  protected override async Task ExecuteAsync(CancellationToken stoppingToken)
  {
    while (!stoppingToken.IsCancellationRequested)
    {
      using (var scope = _provider.CreateScope())
      {
        var api = _factory.GetCurrencyService();
        var result = await api.GetRandomCurrency();
        if (result is not null) {
          var db = scope.ServiceProvider.GetRequiredService<ExchangeDbContext>();
          await db.AddAsync(result);
          await db.SaveChangesAsync();
        }
      }
      _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
      await Task.Delay(1000, stoppingToken);
    }
  }
}
