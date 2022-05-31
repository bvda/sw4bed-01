using MongoDB.Driver;
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
}