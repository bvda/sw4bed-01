using MongoDB.Driver;
using MongoDB.Bson.Serialization;
using mtg_collection.Models;

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
  }
  public MongoClient Client { 
    get {
      return _client;
    }
  }
}