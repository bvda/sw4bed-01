using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MTGCollection.Models;
using MTGCollection.Web.Services;

namespace MTGCollection.Web.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly MtgCollectionService _service;

    public List<SelectListItem> Sets { get; } = new List<SelectListItem> {
        new SelectListItem { Value = "", Text = "All" },
        new SelectListItem { Value = "lea", Text = "Alpha" },
        new SelectListItem { Value = "arn", Text = "Arabian Night" },
        new SelectListItem { Value = "atq", Text = "Antiquities" },
        new SelectListItem { Value = "leg", Text = "Legends" },
    };

    [BindProperty]
    public InputSearchModel SearchModel { get; set; }
    public IList<Card> Cards { get; set; } = new List<Card>();

    public IndexModel(ILogger<IndexModel> logger, MtgCollectionService service)
    {
        _logger = logger;
        _service = service;
    }

    public async Task<IActionResult> OnGetAsync(string name, string type, string setcode)
    {
        Cards = await _service.GetCards(name, type, setcode);
        SearchModel = new InputSearchModel 
        {
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
