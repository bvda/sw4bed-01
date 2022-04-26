using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;

namespace MTGCollection.Models;

public class Deck {
  [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
  public string Id { get; set; } = "";
  public string? Name { get; set; }
  public IList<DeckEntry>? Cards { get; set; }
}