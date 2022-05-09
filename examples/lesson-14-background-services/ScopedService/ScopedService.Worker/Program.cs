using Microsoft.EntityFrameworkCore;

using ScopedService.Worker;
using ScopedService.Data;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
      services.AddHttpClient<ICurrencyService, CurrencyService>();
      services.AddSingleton<ICurrencyServiceFactory, CurrencyServiceFactory>();
      services.AddHostedService<Worker>();
      services.AddHostedService<CorrectWorker>();
      services.AddDbContext<ExchangeDbContext>(options => 
      options
        .UseSqlServer(context.Configuration.GetConnectionString("Exchange"))
      );
    })
    .Build();

await host.RunAsync();
