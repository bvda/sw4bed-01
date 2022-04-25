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
    _client = new MongoClient("mongodb://root:example@localhost:27018");
    var db = _client.GetDatabase("mtg");
    if(_client.GetDatabase("mtg").ListCollections().ToList().Count == 0) {
        var collection = db.GetCollection<Card>("cards");
        foreach(var path in new [] {"lea.json", "arn.json", "atq.json", "leg.json"}) {
          using(var file = new StreamReader(path)) {
              var cards = JsonSerializer.Deserialize<List<Card>>(file.ReadToEnd(), new JsonSerializerOptions {
                  PropertyNameCaseInsensitive = true
              });
              collection.InsertMany(cards);
          }
        }
    }
  }
  public MongoClient Client { 
    get {
      return _client;
    }
  }
}