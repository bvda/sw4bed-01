namespace OrderAPI.API;

public class OrderBackgroundService : BackgroundService
{
  private readonly IServiceProvider _provider;
  
  public OrderBackgroundService(IServiceProvider provider) {
    _provider = provider;
  }

  protected async override Task ExecuteAsync(CancellationToken stoppingToken)
  {
    while (!stoppingToken.IsCancellationRequested) {
      using(var scope = _provider.CreateScope()) {
        var service = scope.ServiceProvider.GetRequiredService<IOrderService>();
        var orders = await service.GetOrders();
        if(orders.Count > 0) {
          service.ProcessOrders();
        } 
      }
      await Task.Delay(TimeSpan.FromSeconds(10), stoppingToken);
    }
  }
}