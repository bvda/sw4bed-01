using System.Text.Json.Serialization;

namespace Lesson07_ContactsAPI.Model;

public class Contact {
  [JsonPropertyName("id")]
  public int ID { get; set; }
  [JsonPropertyName("first_name")]
  public string? FirstName { get; set; }
  [JsonPropertyName("last_name")]
  public string? LastName { get; set; }
  [JsonPropertyName("email")]
  public string? Email { get; set; }
  [JsonPropertyName("gender")]
  public string? Gender { get; set; }
}