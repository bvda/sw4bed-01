using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using BlockchainExplorer.Models;
using BlockchainExplorer.Services;

namespace BlockchainExplorer.Pages.Transactions
{
    public class IndexModel : PageModel
    {
        public int From { get; set; }
        public int To { get; set; }
        public IList<Transaction> Transactions { get; set; }

        public IndexModel(TransactionService transactions) {
            Transactions = transactions.Transactions;
        }

        public void OnGet(int from, int to)
        {
            From = from;
            To = to;
            Transactions = Transactions.Select(t => t).ToList();
            if(From != 0 && To != 0) {
                Transactions = Transactions.Where(t => t.Timestamp >= From && t.Timestamp <= To).ToList();
            } else {
                if(From != 0) {
                    Transactions = Transactions.Where(t => t.Timestamp >= From).ToList();
                }
                if(To != 0) {
                   Transactions = Transactions.Where(t => t.Timestamp <= To).ToList(); 
                }
            }
            var url = Url.Page("/Wallets/Details", new { wallet = Transactions[1].Sender});
            Console.WriteLine(url);
        }
    }
}
