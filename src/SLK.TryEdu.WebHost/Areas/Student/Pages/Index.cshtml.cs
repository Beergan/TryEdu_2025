using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SLK.TryEdu.WebHost.Areas.Student.Models;

namespace SLK.TryEdu.WebHost.Areas.Student.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        [BindProperty]
        public StudentIndexModel StudentModel { get; set; } = new();

        public void OnGet()
        {
            StudentModel.TotalStudents = 1250;
            StudentModel.TotalExams = 45;
            StudentModel.TotalBlogs = 120;

            StudentModel.Categories = new List<SelectListItem>
            {
                new() { Value = "1", Text = "Toán học" },
                new() { Value = "2", Text = "Vật lý" },
                new() { Value = "3", Text = "Hóa học" },
                new() { Value = "4", Text = "Sinh học" },
                new() { Value = "5", Text = "Tiếng Anh" }
            };
        }

        public IActionResult OnPostSearch()
        {
            if (!string.IsNullOrEmpty(StudentModel.SearchTerm))
            {
                _logger.LogInformation("User searched for: {SearchTerm}", StudentModel.SearchTerm);
            }

            return Page();
        }
    }
}