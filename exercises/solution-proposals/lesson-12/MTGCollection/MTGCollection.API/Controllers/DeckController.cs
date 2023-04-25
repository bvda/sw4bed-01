using Microsoft.AspNetCore.Mvc;
using MTGCollection.Data;
using MTGCollection.Models;

namespace MTGCollection.API;

[ApiController]
[Route("[controller]")]
public class DeckController : ControllerBase {

  private readonly ILogger<DeckController> _logger;
  private readonly DeckService _service;

  public DeckController(ILogger<DeckController> logger, DeckService service) 
  {
    _logger = logger;
    _service = service;
  }

  [HttpGet(Name = "GetDeck")]
  public async Task<IList<Deck>> GetAsync() 
  {
    return await _service.GetDeck();
  }

  [HttpPost(Name = "PostDeck")]
  public async void PostAsync(Deck deck)
  {
    await _service.CreateDeck(deck);
  }
}