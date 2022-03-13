using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace UserSecrets.Model;

public class NetLog 
{
  [JsonPropertyName("id")]
  public Guid ID { get; set; }
  [JsonPropertyName("src")]
  public string Source { get; set; }
  [JsonPropertyName("dst")]
  public string Destination { get; set; }
  [JsonPropertyName("user_agent")]
  public string UserAgent { get; set; }
  [JsonPropertyName("port")]
  public int Port { get; set; }
  [JsonPropertyName("date")]
  public DateTime Date { get; set; }
}