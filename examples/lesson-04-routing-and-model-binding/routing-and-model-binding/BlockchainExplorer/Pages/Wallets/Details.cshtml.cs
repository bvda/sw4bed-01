using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using BlockchainExplorer.Models;
using BlockchainExplorer.Services;

namespace BlockchainExplorer.Pages.Wallets
{
    public class DetailsModel : PageModel
    {
        [BindProperty]
        public string Wallet { get; set; } = "";
        public IList<Transaction> Transactions = new List<Transaction>();

        public DetailsModel(TransactionService service) {
            Transactions = service.Transactions;
        }
        public void OnGet(string wallet)
        {
            Wallet = wallet;
        }
    }
}
