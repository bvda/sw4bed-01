using MongoDB.Driver;
using MongoDB.Bson;
using MTGCollection.Models;

namespace MTGCollection.Data;

public class DecksService 
{

  private readonly IMongoCollection<Deck> _collection;
  private readonly MongoService _service;

  public DecksService(MongoService service)
  {
    _service = service;
    _collection = service.Client.GetDatabase("mtg").GetCollection<Deck>("decks");
  }

  public async Task<IList<Deck>> GetDecks()
  {
    return await _collection.Find(Builders<Deck>.Filter.Empty).ToListAsync();
  }

  public async Task CreateDeck(Deck deck) 
  {
    // await _collection.InsertOneAsync(new BsonDocument(deck));
  }
}