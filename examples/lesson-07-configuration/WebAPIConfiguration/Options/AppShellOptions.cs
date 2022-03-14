namespace WebAPIConfiguration.Options;

public class AppShellOptions {
  public const string AppShell = "AppShell";

  public ColorsOption? Colors { get; set; }

  public class ColorsOption {
    public string Primary { get; set; } = String.Empty;
    public string PrimaryLight { get; set; } = String.Empty;
    public string PrimaryDark { get; set; } = String.Empty;
    public string Secondary { get; set; } = String.Empty;
    public string SecondaryLight { get; set; } = String.Empty;
    public string SecondaryDark { get; set; } = String.Empty;
  }
}