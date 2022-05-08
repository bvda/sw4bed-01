using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
      new Currency { Name = "Japanese yen", Symbol = "JPY" },
      new Currency { Name = "Danish krone", Symbol = "DKK"},
      new Currency { Name = "Renminbi", Symbol = "CNY"},
      new Currency { Name = "Swiss franc", Symbol = "CHF"},
      new Currency { Name = "Pound sterling", Symbol = "GBP"},
      new Currency { Name = "Russian ruble", Symbol = "RUB"},
    };
    private readonly ILogger<CurrencyController> _logger;
    private readonly ExchangeDbContext _context;

    public CurrencyController(ILogger<CurrencyController> logger, ExchangeDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet("single", Name = "GetSingle")]
    public ActionResult<Currency> GetSingle()
    {
      return Currencies[new Random().Next(Currencies.Length)];
    }

    [HttpGet("", Name = "GetAll")]
    public async Task<ActionResult<IEnumerable<Currency>>> GetAll()
    {
      return await _context.Currencies.ToListAsync();
    }
}
