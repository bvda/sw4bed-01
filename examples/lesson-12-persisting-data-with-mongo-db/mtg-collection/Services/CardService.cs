using MongoDB.Bson;
using MongoDB.Driver;

namespace mtg_collection.Services;

using mtg_collection.Models;

public class CardService {

  private readonly ILogger<CardService> _logger;
  private readonly IMongoCollection<Card> _collection;
  public CardService(ILogger<CardService> logger, MongoService service) {
    _collection = service.Client.GetDatabase("mtg").GetCollection<Card>("cards");
    _logger = logger;
  }

  public async Task<IList<Card>> Search(string? name = null, string? type = null, string? set = null) {
    var builder = Builders<Card>.Filter;
    var filter = builder.Empty;
    if(name?.Length > 0) {
      filter &= builder.Regex(x => x.Name, new BsonRegularExpression($"/{name}/i"));
    }
    if(type?.Length > 0) {
      filter &= builder.Regex(x => x.Type, new BsonRegularExpression($"/{type}/i"));
    }
    if(set?.Length > 0) {
      filter &= builder.Eq(x => x.SetCode, set);
    }
    return await _collection.Find(filter).ToListAsync();
  }
}