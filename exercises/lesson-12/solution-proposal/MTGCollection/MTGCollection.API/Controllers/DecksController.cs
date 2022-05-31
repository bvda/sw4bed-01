using Microsoft.AspNetCore.Mvc;

namespace MTGCollection.API;

[ApiController]
[Route("[controller]")]
public class DecksController : ControllerBase {

  private readonly ILogger<DecksController> _logger;

  public DecksController(ILogger<DecksController> logger) 
  {
    _logger = logger;
  }

  [HttpGet(Name = "GetDecks")]
  public async void GetAsync() 
  {

  }

  [HttpPost(Name = "PostDeck")]
  public async void PostAsync()
  {

  }
}