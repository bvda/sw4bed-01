using ScopedService.Data;

namespace ScopedService.Worker;

public class CorrectWorker : BackgroundService
{
  private readonly ILogger<CorrectWorker> _logger;
  private readonly ICurrencyServiceFactory _factory;

  public CorrectWorker(ILogger<CorrectWorker> logger,ICurrencyServiceFactory factory)
  {
    _logger = logger;
    _factory = factory;
  }

  protected override async Task ExecuteAsync(CancellationToken stoppingToken)
  {
    while (!stoppingToken.IsCancellationRequested)
    {
      var api = _factory.GetCurrencyService();
      var result = await api.GetRandomCurrency();
      _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
      await Task.Delay(1000, stoppingToken);
    }
  }
}
