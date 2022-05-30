using System.Text.Json;

using MongoDB.Driver;
using MTGCollection.Models;

namespace MTGCollection.Data;

public class CardService {

  private readonly IMongoCollection<Card> _collection;
  private readonly MongoService _service;

  public CardService(MongoService service) {
    _service = service;
    _collection = service.Client.GetDatabase("mtg").GetCollection<Card>("cards");
  }

  public async Task<IList<Card>> GetAllCards() {
    return await _collection.Find<Card>(Builders<Card>.Filter.Empty).ToListAsync();
  }

  public async void SeedCards(string[] paths) {
    foreach(var path in paths) {
      using(var file = new StreamReader(path)) {
        var cards = JsonSerializer.Deserialize<List<Card>>(file.ReadToEnd(), new JsonSerializerOptions {
          PropertyNameCaseInsensitive = true
        });
        await _collection.InsertManyAsync(cards);
      }
    }
  }

  public async Task<bool> IsSeeded() {
    return await _service.IsSeeded("mtg");
  }
}