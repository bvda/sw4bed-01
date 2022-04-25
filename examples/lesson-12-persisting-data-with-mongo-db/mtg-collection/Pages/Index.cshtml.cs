using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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

    public List<SelectListItem> Sets { get; } = new List<SelectListItem> {
        new SelectListItem { Value = "", Text = "All" },
        new SelectListItem { Value = "lea", Text = "Alpha" },
        new SelectListItem { Value = "arn", Text = "Arabian Night" },
        new SelectListItem { Value = "atq", Text = "Antiquities" },
        new SelectListItem { Value = "leg", Text = "Legends" },
    };

    public IndexModel(ILogger<IndexModel> logger, CardService service)
    {
        _logger = logger;
        _service = service;
        SearchModel = new InputSearchModel();
    }

    public async Task<IActionResult> OnGetAsync(string name, string type, string setcode)
    {
        Cards = await _service.Search(name, type, setcode);
        SearchModel = new InputSearchModel {
            Name = name,
            Type = type,
            SetCode = setcode,
        };
        return Page();
    }

    public IActionResult OnPost(string name, string type, string set) {
        return RedirectToPage("Index", new { Name = SearchModel.Name, Type = SearchModel.Type, SetCode = SearchModel.SetCode });
    }

    public class InputSearchModel {
        public string? Name { get; set; }
        public string? Type { get; set; }
        public string? SetCode { get; set; }
    }
}
