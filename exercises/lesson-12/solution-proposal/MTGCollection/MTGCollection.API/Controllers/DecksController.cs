using Microsoft.AspNetCore.Mvc;
using MTGCollection.Data;
using MTGCollection.Models;

namespace MTGCollection.API;

[ApiController]
[Route("[controller]")]
public class DecksController : ControllerBase {

  private readonly ILogger<DecksController> _logger;
  private readonly DecksService _service;

  public DecksController(ILogger<DecksController> logger, DecksService service) 
  {
    _logger = logger;
    _service = service;
  }

  [HttpGet(Name = "GetDecks")]
  public async Task<IList<Deck>> GetAsync() 
  {
    return await _service.GetDecks();
  }

  [HttpPost(Name = "PostDeck")]
  public async void PostAsync(Deck deck)
  {
    await _service.CreateDeck(deck);
  }
}