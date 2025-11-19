using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SLK.TryEdu.WebHost.Classes
{
    /// <summary>
    /// Cấu hình Page Routes cho TryEdu WebHost
    /// </summary>
    public static class PageRouteConfig
    {
        /// <summary>
        /// Cấu hình tất cả Page Routes cho Areas
        /// </summary>
        /// <param name="options">RazorPagesOptions</param>
        public static void ConfigurePageRoutes(RazorPagesOptions options)
        {
            // ========================================
            // STUDENT PORTAL ROUTES
            // ========================================
            ConfigureStudentRoutes(options);

            // ========================================
            // ADMIN PORTAL ROUTES
            // ========================================
            ConfigureAdminRoutes(options);

            // ========================================
            // SHARED ROUTES
            // ========================================
            ConfigureSharedRoutes(options);

            // ========================================
            // API ROUTES
            // ========================================
            ConfigureApiRoutes(options);

            // ========================================
            // FALLBACK ROUTES
            // ========================================
            ConfigureFallbackRoutes(options);
        }

        /// <summary>
        /// Cấu hình Student Portal Routes
        /// </summary>
        private static void ConfigureStudentRoutes(RazorPagesOptions options)
        {
            // Student Home & Auth Routes
            options.Conventions.AddAreaPageRoute("Student", "/Index", "/");
            options.Conventions.AddAreaPageRoute("Student", "/Login", "/login");
            options.Conventions.AddAreaPageRoute("Student", "/Register", "/register");
            options.Conventions.AddAreaPageRoute("Student", "/Dashboard", "/dashboard");
            options.Conventions.AddAreaPageRoute("Student", "/VerifyEmail", "/verifyemail");
            options.Conventions.AddAreaPageRoute("Student", "/CoinWallet", "/coinWallet");
            options.Conventions.AddAreaPageRoute("Student", "/CourseDetail", "/Course/{**slug}");
            options.Conventions.AddAreaPageRoute("Student", "/Courses", "/Courses");
            options.Conventions.AddAreaPageRoute("Student", "/QuizDetail", "/quiz/{**slug}");
            options.Conventions.AddAreaPageRoute("Student", "/Quizzes", "/quiz");
            options.Conventions.AddAreaPageRoute("Student", "/FreeCourses", "/freeCourses");

        }

        /// <summary>
        /// Cấu hình Admin Portal Routes
        /// </summary>
        /// <summary>
        /// Cấu hình Admin Portal Routes
        /// </summary>
        private static void ConfigureAdminRoutes(RazorPagesOptions options)
        {
            options.Conventions.AddAreaPageRoute("Admin", "/Login", "/admin/login");
            //options.Conventions.AddAreaPageRoute("Admin", "/_AdminHost", "/admin");
            options.Conventions.AddAreaPageRoute("Admin", "/_AdminHost", "/admin/{**slug}");
            options.Conventions.AddAreaPageRoute("Admin", "/ForgotPassword", "/admin/forgot-password/{**slug}");
            options.Conventions.AddAreaPageRoute("Admin", "/ResetPassword", "/admin/reset-password/{**slug}");
        }
        /// <summary>
        /// Cấu hình Shared Routes
        /// </summary>
        private static void ConfigureSharedRoutes(RazorPagesOptions options)
        {
            // Error Pages
            options.Conventions.AddPageRoute("/Error", "/error");
            options.Conventions.AddPageRoute("/NotFound", "/404");
            options.Conventions.AddPageRoute("/AccessDenied", "/403");
            options.Conventions.AddPageRoute("/Maintenance", "/maintenance");

            options.Conventions.AddPageRoute("/ForgotPassword", "/forgot-password");
            options.Conventions.AddPageRoute("/ResetPassword", "/reset-password");
        }

        /// <summary>
        /// Cấu hình API Routes
        /// </summary>
        private static void ConfigureApiRoutes(RazorPagesOptions options)
        {
            // Student API Routes
            options.Conventions.AddAreaPageRoute("Student", "/Api/Student", "/api/student");

            // Admin API Routes
            options.Conventions.AddAreaPageRoute("Admin", "/Api/Admin", "/api/admin");
        }

        /// <summary>
        /// Cấu hình Fallback Routes
        /// </summary>
        private static void ConfigureFallbackRoutes(RazorPagesOptions options)
        {
            // Fallback routes for better SEO
            options.Conventions.AddPageRoute("/Index", "/home");
            options.Conventions.AddPageRoute("/Index", "/trang-chu");
            options.Conventions.AddPageRoute("/Blog/Index", "/bai-viet");
            options.Conventions.AddPageRoute("/News/Index", "/tin-tuc");
            options.Conventions.AddPageRoute("/Materials/Index", "/tai-lieu");
            options.Conventions.AddPageRoute("/Exams/Index", "/de-thi");
        }

        /// <summary>
        /// Cấu hình Custom Route Constraints
        /// </summary>
        public static void ConfigureCustomConstraints(RazorPagesOptions options)
        {
            // Add custom route constraints if needed
            options.Conventions.AddPageRoute("/Blog/Details", "/blog/{id:int:min(1)}");
            options.Conventions.AddPageRoute("/News/Details", "/news/{id:int:min(1)}");
            options.Conventions.AddPageRoute("/Materials/Download", "/materials/download/{id:int:min(1)}");
        }

        /// <summary>
        /// Cấu hình SEO Friendly Routes
        /// </summary>
        public static void ConfigureSeoRoutes(RazorPagesOptions options)
        {
            // Vietnamese routes for better SEO
            options.Conventions.AddPageRoute("/Index", "/trang-chu");
            options.Conventions.AddPageRoute("/Blog/Index", "/bai-viet");
            options.Conventions.AddPageRoute("/News/Index", "/tin-tuc");
            options.Conventions.AddPageRoute("/Materials/Index", "/tai-lieu");
            options.Conventions.AddPageRoute("/Exams/Index", "/de-thi");
            options.Conventions.AddPageRoute("/About/Index", "/gioi-thieu");
            options.Conventions.AddPageRoute("/Help/Index", "/tro-giup");
        }
    }
}