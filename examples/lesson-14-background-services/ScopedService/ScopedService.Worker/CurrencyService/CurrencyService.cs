using System.Net.Http.Json;
using ScopedService.Data;

namespace ScopedService.Worker;

public interface ICurrencyService {
  public Task<Currency?> GetRandomCurrency();
}

public class CurrencyService: ICurrencyService {
  private readonly HttpClient _client;
  
  public CurrencyService(HttpClient client) {
    _client = client;
    _client.BaseAddress = new Uri("https://localhost:5000");
  }

  public async Task<Currency?> GetRandomCurrency() {
    return await _client.GetFromJsonAsync<Currency>("api/currencies/single");
  }
}