using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SLK.TryEdu.WebHost.Areas.Student.Pages
{
    public class QuizDetailModel : PageModel
    {
        public int QuizId { get; set; }

        public void OnGet(int id)
        {
            QuizId = id;
        }
    }
}

