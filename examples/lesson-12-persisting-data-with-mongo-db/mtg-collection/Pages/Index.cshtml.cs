using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using mtg_collection.Services;
using mtg_collection.Models;

namespace mtg_collection.Pages;

public class IndexModel : PageModel
{

    [BindProperty]
    public InputSearchModel SearchModel { get; set; }
    private readonly ILogger<IndexModel> _logger;
    private readonly CardService _service;

    public IList<Card> Cards { get; set; } = new List<Card>();

    public List<string> Sets {get; set; } = new List<string>();

    public IndexModel(ILogger<IndexModel> logger, CardService service)
    {
        _logger = logger;
        _service = service;
        SearchModel = new InputSearchModel();
    }

    public async Task<IActionResult> OnGetAsync(string name, string type, string set)
    {
        Cards = await _service.Search(name, type, set);
        // Console.WriteLine(name+type+set);
        SearchModel = new InputSearchModel {
            Name = name,
            Type = type,
            SetCode = set,
        };
        return Page();
    }

    public async Task<IActionResult> OnPostAsync(string name, string type, string set) {
        // await _service.Search(SearchModel.Name, SearchModel.Type, SearchModel.SetCode);
        return RedirectToPage("Index", new { Name = SearchModel.Name, Type = SearchModel.Type, SetCode = SearchModel.SetCode});
    }

    public class InputSearchModel {
        public string? Name { get; set; }
        public string? Type { get; set; }
        public string? SetCode { get; set; }
    }
}
