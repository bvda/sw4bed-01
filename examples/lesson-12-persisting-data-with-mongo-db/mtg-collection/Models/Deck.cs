using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace mtg_collection.Models;

public class Deck {
  [BsonRepresentation(BsonType.ObjectId)]
  public string Id { get; set; }
  public string? Name { get; set; }
  public IList<DeckEntry>? Cards { get; set; }
}