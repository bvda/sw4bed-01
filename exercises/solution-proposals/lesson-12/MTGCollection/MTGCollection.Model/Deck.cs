
namespace MTGCollection.Models;

public class Deck {
  public string? Id { get; set; } = null;
  public string? Name { get; set; } = null;
  public IList<DeckEntry> Cards { get; set; } = new List<DeckEntry>();
}