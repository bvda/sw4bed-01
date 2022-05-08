using Microsoft.EntityFrameworkCore;

using ScopedService.Worker;
using ScopedService.Data;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
      services.AddHostedService<Worker>();
      services.AddHttpClient<CurrencyService>();
      services.AddDbContext<ExchangeDbContext>(options => options.UseInMemoryDatabase("Exchange"));
    })
    .Build();

using (var scope = host.Services.CreateScope())
{
  var services = scope.ServiceProvider;
  try
  {
    var context = services.GetRequiredService<ExchangeDbContext>();
    context.Database.EnsureCreated();
    var currencies = context.Currencies.FirstOrDefault();
    if (currencies == null)
    {

    }
    context.SaveChanges();
  }
  catch (Exception ex)
  {
    var logger = services.GetRequiredService<ILogger<Program>>();
    logger.LogError("An error occurred while seeding the database", ex.Message);
  }
}

await host.RunAsync();
