using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using mtg_collection.Services;
namespace mtg_collection.Pages.Deck;

public class IndexModel : PageModel
{

    [BindProperty]
    public InputModel Input { get; set; }
    private readonly DeckService _service;

    public IList<Models.Deck> Decks { get; set; } = new List<Models.Deck>();
    public IndexModel(DeckService service) {
        _service = service;
    }
    public async Task<IActionResult> OnGet(string? id)
    {
        Decks = await _service.GetDecks(id);
        // Input = new InputModel {
        //     Name = id;
        // };
        return Page();
    }

    public IActionResult OnPost() {
         _service.CreateDeck(new Models.Deck {
            Name = "Test"
        });
        return RedirectToPage("/Deck/Index");
    }

    public class InputModel {
    public string? Name { get; set; }
    }
}
