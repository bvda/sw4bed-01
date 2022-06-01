using System.Text.Json.Serialization;

namespace MTGCollection.Models;

public class Card {
  public string Id { get; set; } = "";
  [JsonPropertyName("oracle_id")]
  public string OracleId { get; set; } = "";
  public string Name { get; set; } = "";
  [JsonPropertyName("mana_cost")]
  public string ManaCost { get; set; } = "";
  [JsonPropertyName("type_line")]
  public string Type { get; set; } = "";
  [JsonPropertyName("cmc")]
  public float ConvertedManaCost { get; set; }
  [JsonPropertyName("oracle_text")]
  public string OracleText { get; set; } = "";
  public string? Power { get; set; }
  public string? Toughness { get; set; }
  [JsonPropertyName("set_name")] 
  public string Set { get; set; } = "";
  [JsonPropertyName("set")]  
  public string SetCode { get; set; }
  public string Rarity { get; set; } = "";
  public string Artist { get; set; } = "";
  [JsonPropertyName("image_uris")]
  public ImageUris? ImageUris { get; set; } 
}