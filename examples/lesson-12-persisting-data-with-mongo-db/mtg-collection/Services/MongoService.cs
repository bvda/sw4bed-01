using MongoDB.Driver;
using MongoDB.Bson.Serialization;
using mtg_collection.Models;
using System.Text.Json;

namespace mtg_collection.Services;

public class MongoService {
  
  private readonly MongoClient _client;
  public MongoService() {
    BsonClassMap.RegisterClassMap<Card>(cm => {
      cm.AutoMap();
      cm.SetIgnoreExtraElements(true);
    });
    // BsonClassMap.RegisterClassMap<Deck>(cm => {
    //   cm.AutoMap();
    //   cm.SetIgnoreExtraElements(true);
    // });
    _client = new MongoClient("mongodb://root:example@localhost:27017");
    var db = _client.GetDatabase("mtg");
    if(_client.GetDatabase("mtg").ListCollections().ToList().Count == 0) {
        var collection = db.GetCollection<Card>("cards");
        using(var file = new StreamReader("lea-p1.json")) {
            var cards = JsonSerializer.Deserialize<List<Card>>(file.ReadToEnd(), new JsonSerializerOptions {
                PropertyNameCaseInsensitive = true
            });
            collection.InsertMany(cards);
        }
    }
  }
  public MongoClient Client { 
    get {
      return _client;
    }
  }
}