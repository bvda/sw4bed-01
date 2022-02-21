using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using BlockchainExplorer.Services;

namespace BlockchainExplorer.Pages.Wallets
{
    public class IndexModel : PageModel
    {
        public IList<string> Wallets;

        public IndexModel(TransactionService transactions) {
            Wallets = new TransactionService().Wallets.Select(m => m.Sender).Distinct().ToList();
        }
        public void OnGet()
        {
        }
        
        public IActionResult OnGetDetails(string wallet) {
            return RedirectToPage("/Wallets/Details", new { Wallet = wallet });
        }
    }
}
