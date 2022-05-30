using Microsoft.AspNetCore.Mvc;
using MTGCollection.Data; 
using MTGCollection.Models;

namespace MTGCollection.API;

[ApiController]
[Route("[controller]")]
public class CardsController : ControllerBase 
{
  private readonly ILogger<CardsController> _logger;
  private readonly CardService _cardService;

  public CardsController(ILogger<CardsController> logger, CardService cardService) 
  {
    _logger = logger;
    _cardService = cardService;
  }

  [HttpGet(Name = "GetCards")]
  public async Task<IList<Card>> GetAsync(string? name = "", string? type = null, string? set = null) {
    return await _cardService.Search(name, type, set);
  }
}