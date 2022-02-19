using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BlockchainExplorer.Pages.Wallets
{
    public class DetailsModel : PageModel
    {
        public string Wallet { get; set; }
        public void OnGet(string wallet)
        {
            Wallet = wallet;
        }
    }
}
