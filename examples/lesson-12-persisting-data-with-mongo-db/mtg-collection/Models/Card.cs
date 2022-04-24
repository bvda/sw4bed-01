using System.Text.Json.Serialization;

namespace mtg_collection.Data;

public class Card {
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
  public string Rarity { get; set; } = "";
  [JsonPropertyName("image_uris")]
  public string Artist { get; set; } = "";
  public ImageUris? ImageUris { get; set; } 
}