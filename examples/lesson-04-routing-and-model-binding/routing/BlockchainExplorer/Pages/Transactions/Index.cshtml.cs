using System.ComponentModel.DataAnnotations;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using BlockchainExplorer.Models;
using BlockchainExplorer.Services;

namespace BlockchainExplorer.Pages.Transactions
{
  public class IndexModel : PageModel 
  {
    [BindProperty]
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

    public void OnGet(TransactionsIndexBindingModel model)
    {
      Transactions = _service.OrderBy(model.Ascending).Filter(model.From, model.To).Transactions;
    }

    public IActionResult OnPost() {
      if(!ModelState.IsValid) {
        Console.WriteLine("Invalid model");
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
    public int To { get; set; }
    [Required]
    public int From { get; set; }

  }
}