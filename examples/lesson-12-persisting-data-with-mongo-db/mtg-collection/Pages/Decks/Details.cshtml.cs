using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MTGCollection.Services;
using MTGCollection.Models;

namespace MTGCollection.Pages.Decks;

public class DetailsModel : PageModel
{
    // [BindProperty]
    // public InputModel? Input { get; set; }
    private readonly DeckService _service;

    public Deck Deck { get; set; } = new Deck();
    public DetailsModel(DeckService service) {
        _service = service;
    }
    public async Task<IActionResult> OnGet(string? id)
    {
        var result = await _service.GetDecks(id);
        Deck = result.First();
        return Page();
    }

    // public IActionResult OnPost() {
    //     _service.CreateDeck(new Deck {
    //         Name = Input?.Name/
    //     });
    //     return RedirectToPage("/Decks/Index");
    // }

    // public class InputModel {
    //     public string? Name { get; set; }
    // }
}
