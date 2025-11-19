using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SLK.TryEdu.WebHost.Classes
{
    /// <summary>
    /// Extensions cho Page Route Configuration
    /// </summary>
    public static class PageRouteExtensions
    {

        public static RazorPagesOptions AddTryEduRoutes(this RazorPagesOptions options)
        {
            PageRouteConfig.ConfigurePageRoutes(options);
            return options;
        }

        public static RazorPagesOptions AddTryEduRoutes(this RazorPagesOptions options, bool enableCustomConstraints = false)
        {
            PageRouteConfig.ConfigurePageRoutes(options);

            if (enableCustomConstraints)
            {
                PageRouteConfig.ConfigureCustomConstraints(options);
            }

            return options;
        }

        
        public static RazorPagesOptions AddTryEduRoutes(this RazorPagesOptions options, bool enableCustomConstraints = false, bool enableSeo = false)
        {
            PageRouteConfig.ConfigurePageRoutes(options);

            if (enableCustomConstraints)
            {
                PageRouteConfig.ConfigureCustomConstraints(options);
            }

            if (enableSeo)
            {
                PageRouteConfig.ConfigureSeoRoutes(options);
            }

            return options;
        }
    }
}