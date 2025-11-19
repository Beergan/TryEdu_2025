using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SLK.TryEdu.WebHost.Areas.Student.Pages
{
    public class CourseDetailModel : PageModel
    {
        public int CourseId { get; set; }

        public void OnGet(int id)
        {
            CourseId = id;
        }
    }
}

