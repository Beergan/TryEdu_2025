using Microsoft.AspNetCore.Mvc.Rendering;

namespace SLK.TryEdu.WebHost.Areas.Student.Models
{
    public class StudentIndexModel
    {
        public string WelcomeMessage { get; set; } = "Chào mừng đến với TryEdu!";
        public List<SelectListItem> Categories { get; set; } = new();
        public string SearchTerm { get; set; } = string.Empty;
        public int TotalStudents { get; set; } = 0;
        public int TotalExams { get; set; } = 0;
        public int TotalBlogs { get; set; } = 0;
    }
}