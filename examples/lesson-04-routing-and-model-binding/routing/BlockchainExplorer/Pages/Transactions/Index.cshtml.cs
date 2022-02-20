using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using BlockchainExplorer.Models;
using BlockchainExplorer.Services;

namespace BlockchainExplorer.Pages.Transactions
{
  public class IndexModel : PageModel 
  {
    [BindProperty]
    public TransactionsIndexBindingModel bindingModel { get; set; }
    public IList<Transaction> Transactions { get; set; }

    public IndexModel(TransactionService transactions)
    {
      Transactions = transactions.Transactions;
    }

    public void OnGet(TransactionsIndexBindingModel model)
    {
      Transactions = OrderList(model, Filter(model));
    }

    private IList<Transaction> Filter(TransactionsIndexBindingModel model) {
      Transactions = Transactions.Select(t => t).ToList();
      if (model.From != 0 && model.To != 0)
      {
        Transactions = Transactions.Where(t => t.Timestamp >= model.From && t.Timestamp <= model.To).ToList();
      }
      else
      {
        if (model.From != 0)
        {
          Transactions = Transactions.Where(t => t.Timestamp >= model.From).ToList();
        }
        if (model.To != 0)
        {
          Transactions = Transactions.Where(t => t.Timestamp <= model.To).ToList();
        }
      }
      return Transactions.ToList();
    }

    private IList<Transaction> OrderList(TransactionsIndexBindingModel model, IList<Transaction> list) {
      if(model.Ascending) {
          return list.OrderBy(t => t.Timestamp).ToList();
      } else {
          return list.OrderByDescending(t => t.Timestamp).ToList();
      }        
    }
  }

  public class TransactionsIndexBindingModel
  {
    public int To { get; set; }
    public int From { get; set; }
    public bool Ascending { get; set; }
  }
}