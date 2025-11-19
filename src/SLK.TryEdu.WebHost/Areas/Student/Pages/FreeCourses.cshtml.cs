using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SLK.TryEdu.WebHost.Areas.Student.Pages
{
    public class FreeCoursesModel : PageModel
    {
        // Sample data for free courses
        public int TotalFreeCourses { get; set; } = 50;
        public int TotalLessons { get; set; } = 200;
        public int TotalStudents { get; set; } = 15200;
        
        public void OnGet()
        {
            // TODO: Load free courses from database
            // var freeCourses = await _courseService.GetFreeCourses();
        }
    }
}

