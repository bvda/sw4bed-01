using MongoDB.Bson;
using MongoDB.Driver;
using webapi;

namespace webapi.Services;

public class WeatherRepository : IMongoRepository {

  private MongoClient _client;
  private IMongoDatabase _database;

  public WeatherRepository(string connection) {
    _client = new MongoClient(connection);
    _database = _client.GetDatabase("test");
  }

  public async Task<IEnumerable<WeatherForecast>> GetAll() {
    return await _database.GetCollection<WeatherForecast>("bar").Find(new BsonDocument()).ToListAsync();
  }

  public async Task Create(WeatherForecast forecast)
  {
    await _database.GetCollection<WeatherForecast>("bar").InsertOneAsync(forecast);
  }
}