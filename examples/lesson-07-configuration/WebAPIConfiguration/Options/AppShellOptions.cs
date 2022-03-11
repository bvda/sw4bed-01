namespace WebAPIConfiguration.Options;

public class AppShellOptions {
  public const string AppShell = "AppShell";

  public ColorsOption Colors { get; set; }

  public class ColorsOption {
    public string Primary { get; set; } = String.Empty;
    public string Secondary { get; set; } = String.Empty;
    public string Tertiary { get; set; } = String.Empty;
    public string PrimaryContainer { get; set; } = String.Empty;
    public string SecondaryContainer { get; set; } = String.Empty;
    public string TertiaryContainer { get; set; } = String.Empty;
  }
}