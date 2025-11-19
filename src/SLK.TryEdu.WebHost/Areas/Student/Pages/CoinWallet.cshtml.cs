using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SLK.TryEdu.WebHost.Areas.Student.Pages
{
    public class CoinWalletModel : PageModel
    {
        // Sample data - replace with actual database queries
        public decimal CurrentBalance { get; set; } = 1250;
        public decimal TotalDeposited { get; set; } = 2000;
        public decimal TotalUsed { get; set; } = 750;
        
        public void OnGet()
        {
            // TODO: Load user's coin balance from database
            // CurrentBalance = await _coinService.GetBalance(userId);
        }
    }
}

