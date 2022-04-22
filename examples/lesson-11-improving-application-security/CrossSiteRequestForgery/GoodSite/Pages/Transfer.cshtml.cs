using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GoodSite.Pages
{

    public class TransferModel : PageModel
    {

        private readonly ILogger<TransferModel> _logger;

        public TransferModel(ILogger<TransferModel> logger) {
            _logger = logger;
        }

        public void OnGet()
        {
        }
        
        [IgnoreAntiforgeryToken]
        public void OnPost()
        {
            _logger.LogDebug("OnTransferPost");
        }
    }
}
