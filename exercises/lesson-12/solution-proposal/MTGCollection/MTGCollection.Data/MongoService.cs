using MongoDB.Driver;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using MTGCollection.Models;

namespace MTGCollection.Data;

public class MongoService {
  
  private readonly MongoClient _client;

  public MongoClient Client {
    get {
      return _client;
    }
  }

  public MongoService(string connectionString) {
    BsonClassMap.RegisterClassMap<Deck>(cm => 
    {
      cm.AutoMap();
      cm.MapIdField(c => c.Id).SetIdGenerator(StringObjectIdGenerator.Instance);
    });
    BsonClassMap.RegisterClassMap<Card>(cm => {
      cm.AutoMap();
      cm.MapIdField(c => c.Id).SetIdGenerator(StringObjectIdGenerator.Instance);
    });
    _client = new MongoClient(connectionString);
  }

  public async Task<bool> IsSeeded(string database) {
    var cursor = await _client.GetDatabase(database).ListCollectionsAsync();
    return (await cursor.ToListAsync()).Count > 0;
  }
}