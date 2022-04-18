using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CrossSiteScripting.Services;


namespace CrossSiteScripting.Pages;

public class IndexModel : PageModel
{
  private readonly ILogger<IndexModel> _logger;
  private readonly NameService _service;

  [BindProperty]
  public string FormInput { get; set; } = "";

  public IList<string> Names { 
    get {
      return _service.Names;
    }
  }

  public IndexModel(ILogger<IndexModel> logger, NameService service) 
  {
    _logger = logger;
    _service = service;
  }

  public void OnGet()
  {

  }

  public IActionResult OnPost()
  {
    _service.Add(FormInput);
     return RedirectToPage("Index");
  }
}
