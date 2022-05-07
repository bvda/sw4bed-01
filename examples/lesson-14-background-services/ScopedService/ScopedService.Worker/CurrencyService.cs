using System.Net.Http.Json;
using ScopedService.Data;

namespace ScopedService.Worker;

public class CurrencyService {
  private readonly HttpClient _client;
  
  public CurrencyService(HttpClient client) {
    _client = client;
    _client.BaseAddress = new Uri("https://localhost:5000");
  }

  public async Task<IEnumerable<Currency>?> GetCurrencies() {
    return await _client.GetFromJsonAsync<IEnumerable<Currency>>("/api/currencies");
  }
}