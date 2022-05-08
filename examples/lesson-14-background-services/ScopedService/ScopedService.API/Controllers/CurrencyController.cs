using Microsoft.AspNetCore.Mvc;

using ScopedService.Data;

namespace ScopedService.API.Controllers;

[ApiController]
[Route("api/currencies")]
public class CurrencyController : ControllerBase
{
    private static readonly Currency[] Currencies = new[]
    {
      new Currency { Name = "United States dollar", Symbol = "USD" },
      new Currency { Name = "Euro", Symbol = "EUR" },
      new Currency { Name = " Japanese yen", Symbol = "JPY" },
    };
    private readonly ILogger<CurrencyController> _logger;

    public CurrencyController(ILogger<CurrencyController> logger)
    {
        _logger = logger;
    }

    [HttpGet("single", Name = "GetSingle")]
    public ActionResult<Currency> GetSingle()
    {
      return Currencies[new Random().Next(Currencies.Length)];
    }

    [HttpGet("", Name = "GetAll")]
    public ActionResult<Currency[]> GetAll()
    {
      return Currencies;
    }
}
