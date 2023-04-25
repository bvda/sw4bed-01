using MongoDB.Driver;
using MTGCollection.Models;

namespace MTGCollection.Data;

public class DeckService 
{

  private readonly IMongoCollection<Deck> _collection;
  private readonly MongoService _service;

  public DeckService(MongoService service)
  {
    _service = service;
    _collection = service.Client.GetDatabase("mtg").GetCollection<Deck>("decks");
  }

  public async Task<IList<Deck>> GetDeck()
  {
    return await _collection.Find(Builders<Deck>.Filter.Empty).ToListAsync();
  }

  public async Task CreateDeck(Deck deck)
  {
    var cards = _service.Client.GetDatabase("mtg").GetCollection<Card>("cards");
    var card = await cards.Find(Builders<Card>.Filter.Where(c => c.Name == "Black Lotus")).FirstAsync();
    deck.Cards.Add(new DeckEntry {
      Quantity = 1,
      Card = card
    });
    Console.WriteLine(card);
    await _collection.InsertOneAsync(deck);
  }
}