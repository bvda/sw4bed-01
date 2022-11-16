using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MTGCollection.Services;
using MTGCollection.Models;

namespace MTGCollection.Pages.Decks;

public class IndexModel : PageModel
{
    [BindProperty]
    public InputModel Input { get; set; }
    private readonly DeckService _service;

    public IList<Deck> Decks { get; set; } = new List<Deck>();
    public IndexModel(DeckService service) {
        _service = service;
        Input = new InputModel();
    }
    public async Task<IActionResult> OnGet(string? id)
    {
        Decks = await _service.GetDecks(id);
        return Page();
    }

    public IActionResult OnPost() {
        _service.CreateDeck(new Deck {
            Name = Input?.Name
        });
        return RedirectToPage("/Decks/Index");
    }

    public class InputModel {
        public string? Name { get; set; }
    }
}
