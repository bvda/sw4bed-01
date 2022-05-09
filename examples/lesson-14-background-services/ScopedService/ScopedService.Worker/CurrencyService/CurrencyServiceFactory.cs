namespace ScopedService.Worker;

public interface ICurrencyServiceFactory 
{
  ICurrencyService GetCurrencyService();
}

public class CurrencyServiceFactory : ICurrencyServiceFactory 
{
  private readonly IServiceProvider _provider;

  public CurrencyServiceFactory(IServiceProvider provider) 
  {
    _provider = provider;
  }

  public ICurrencyService GetCurrencyService() 
  {
    return _provider.GetRequiredService<ICurrencyService>();
  }
}