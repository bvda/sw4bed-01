using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GoodSite.Pages
{
    [IgnoreAntiforgeryToken(Order=1001)]
    public class TransferModel : PageModel
    {

        [BindProperty]
        public TransferRequest? TransferDTO { get; set; }

        private readonly ILogger<TransferModel> _logger;

        public TransferModel(ILogger<TransferModel> logger) {
            _logger = logger;
        }

        public void OnGet()
        {
        }
        
        public void OnPost(TransferRequest request)
        {
        _logger.LogWarning($"OnTransferPost {request.Transaction} {request.Amount} to {request.Account}");
        }
    }

    public class TransferRequest {
        public required string Transaction { get; set; }
        public decimal Amount { get; set; }
        public required string Account { get; set; }
    }
}
