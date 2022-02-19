using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using BlockchainExplorer.Services;

namespace BlockchainExplorer.Pages.Wallets
{
    public class IndexModel : PageModel
    {
        public IList<String> Transactions;

        public IndexModel(TransactionService transactions) {
            Transactions = new TransactionService().Wallets.Select(m => m.Sender).ToList();
        }
        public void OnGet()
        {
        }
        
        public IActionResult OnGetDetails(string wallet) {
            return RedirectToPage("/Wallets/Details", new { wallet });
        }
    }
}
