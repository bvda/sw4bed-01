using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using BlockchainExplorer.Models;
using BlockchainExplorer.Services;

namespace BlockchainExplorer.Pages.Wallets
{
    public class DetailsModel : PageModel
    {
        public IList<Transaction> Transactions = new List<Transaction>();
        public string Wallet { get; set; }


        public DetailsModel(TransactionService service) {
            Transactions = service.Transactions;
        }
        public void OnGet(string wallet)
        {
            Wallet = wallet;
        }
    }
}
