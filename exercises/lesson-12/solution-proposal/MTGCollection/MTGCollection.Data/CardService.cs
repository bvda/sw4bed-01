using System.Text.Json;

using MongoDB.Bson;
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

  public async Task<IList<Card>> Search(string? name = null, string? type = null, string? set = null, string? artist = null, int? page = null) {
    var builder = Builders<Card>.Filter;
    var filter = builder.Empty;
    var limit = 100;

    if(name?.Length > 0) {
      filter &= builder.Regex(x => x.Name, new BsonRegularExpression($"/{name}/i"));
    }

    if(type?.Length > 0) {
      filter &= builder.Regex(x => x.Type, new BsonRegularExpression($"/{type}/i"));
    }

    if(set?.Length > 0) {
      filter &= builder.Eq(x => x.SetCode, set);
    }

    if(artist?.Length > 0) {
      filter &= builder.Regex(x => x.Artist, new BsonRegularExpression($"/{artist}/i"));
    } 
    Console.WriteLine(page * limit);
    return await _collection.Find(filter).Skip(page * limit).Limit(limit).ToListAsync();
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