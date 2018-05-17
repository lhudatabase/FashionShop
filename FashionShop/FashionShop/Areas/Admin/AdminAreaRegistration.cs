using System.Web.Mvc;

namespace FashionShop.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Dashboard",
                "Admin/dashboard",
                new { action = "Dashboard", controller = "Admin", id = UrlParameter.Optional }
            );

            context.MapRoute(
                "Messages",
                "Admin/messages",
                new { action = "Messages", controller = "Admin", id = UrlParameter.Optional }
            );

            context.MapRoute(
                "Forms",
                "Admin/forms",
                new { action = "Forms", controller = "Admin", id = UrlParameter.Optional }
            );

            context.MapRoute(
                "Gallery",
                "Admin/gallery",
                new { action = "Gallery", controller = "Admin", id = UrlParameter.Optional }
            );

            context.MapRoute(
                "UsersAccount",
                "Admin/users-account",
                new { action = "UsersAccount", controller = "Admin", id = UrlParameter.Optional }
            );

            context.MapRoute(
                "Calendar",
                "Admin/calendar",
                new { action = "Calendar", controller = "Admin", id = UrlParameter.Optional }
            );

            context.MapRoute(
                "FileManager",
                "Admin/file-manager",
                new { action = "FileManager", controller = "Admin", id = UrlParameter.Optional }
            );

            context.MapRoute(
                "Icon",
                "Admin/icon",
                new { action = "Icon", controller = "Admin", id = UrlParameter.Optional }
            );

            context.MapRoute(
                "Login",
                "login",
                new { action = "Index", controller = "Login", id = UrlParameter.Optional }
            );

            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new { action = "Index", controller = "Admin", id = UrlParameter.Optional }
            );
        }
    }
}