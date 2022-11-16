using MTGCollection.Models;
using System.Net.Http.Json;

namespace MTGCollection.Web.Services;

public class MtgCollectionService {
  private readonly HttpClient _client;

  public MtgCollectionService(HttpClient client) {
    _client = client;
    _client.BaseAddress = new Uri("https://localhost:5001");
  }

  public async Task<IList<Card>> GetCards(string name, string type, string set, string artist) 
  {
    return await _client.GetFromJsonAsync<IList<Card>>($"cards?name={name}&type={type}&set={set}&artist={artist}");
  }
}