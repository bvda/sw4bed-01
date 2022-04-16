namespace CrossSiteScripting.Services;

public class NameService {
  private readonly IList<string> _names = new List<string>();
  public IList<string> Names { get; set; }
  public NameService() {
    Names = _names;
  }
  public void Add(string name) {
    if(!string.IsNullOrEmpty(name)) {
      _names.Add(name);
    }
  }
}