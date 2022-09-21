using System.ComponentModel.DataAnnotations;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using BlockchainExplorer.Models;
using BlockchainExplorer.Services;
using BlockchainExplorer.Validation;

namespace BlockchainExplorer.Pages.Transactions
{
  public class IndexModel : PageModel 
  {
    [BindProperty(SupportsGet = true)]
    public TransactionsIndexBindingModel BindingModel { get; set; }

    [BindProperty]
    public TimeFilter TimeFilter { get; set; }
    
    public IList<Transaction> Transactions { get; set; }
    private TransactionService _service;

    public IndexModel(TransactionService service)
    {
      _service = service;
      Transactions = _service.Transactions;
    }

    public void OnGet()
    {
      if(BindingModel is not null) {
        TimeFilter = new TimeFilter {
          To = BindingModel.To,
          From = BindingModel.From,
        };
        Transactions = _service.OrderBy(BindingModel.Ascending).Filter(BindingModel.From, BindingModel.To).Transactions;
      }
    }

    public IActionResult OnPost() {
      if(!ModelState.IsValid) {
        return Page();
      }
      return RedirectToPage("Index", new { To = TimeFilter.To, From = TimeFilter.From, Ascending = BindingModel.Ascending });
    }
  }

  public class TransactionsIndexBindingModel
  {
    public int To { get; set; }
    public int From { get; set; }
    public bool Ascending { get; set; }
  }

  public class TimeFilter {
    [Required]
    [BitcoinGenesisRange]
    public int To { get; set; }
    
    [BitcoinGenesisRange]
    public int? From { get; set; }

  }
}