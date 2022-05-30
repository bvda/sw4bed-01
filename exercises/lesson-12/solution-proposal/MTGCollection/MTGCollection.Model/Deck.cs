
namespace MTGCollection.Models;

public class Deck {
  public string Id { get; set; } = "";
  public string? Name { get; set; }
  public IList<DeckEntry>? Cards { get; set; }
}