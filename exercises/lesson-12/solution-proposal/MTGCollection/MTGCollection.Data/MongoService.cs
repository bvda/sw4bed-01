using MongoDB.Driver;

namespace MTGCollection.Data;

public class MongoService {
  
  private readonly MongoClient _client;

  public MongoClient Client {
    get {
      return _client;
    }
  }

  public MongoService() {
    _client = new MongoClient(/* connection string */); 
  }
}