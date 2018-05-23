using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace FashionShop
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            #region ShopController
            routes.MapRoute(
               name: "Products",
               url: "products",
               defaults: new { controller = "Shop", action = "Products", id = UrlParameter.Optional }
           );

            routes.MapRoute(
               name: "Services",
               url: "services",
               defaults: new { controller = "Shop", action = "Services", id = UrlParameter.Optional }
           );

            routes.MapRoute(
              name: "Add Cart",
              url: "them-gio-hang",
              defaults: new { controller = "Cart", action = "AddItem", id = UrlParameter.Optional },
               namespaces: new[] { "FashionShop.Controllers" }
          );

            routes.MapRoute(
          name: "Cart",
          url: "cart",
          defaults: new { controller = "Cart", action = "Index", id = UrlParameter.Optional },
          namespaces: new[] { "FashionShop.Controllers" }
          );

            routes.MapRoute(
           name: "Payment Success",
           url: "success",
           defaults: new { controller = "Cart", action = "Success", id = UrlParameter.Optional },
           namespaces: new[] { "FashionShop.Controllers" }
          );

            routes.MapRoute(
             name: "Payment",
             url: "payment",
             defaults: new { controller = "Cart", action = "Payment", id = UrlParameter.Optional },
             namespaces: new[] { "FashionShop.Controllers" }
         );

            routes.MapRoute(
           name: "Payment Failed",
           url: "loi-thanh-toan",
           defaults: new { controller = "Cart", action = "Failed", id = UrlParameter.Optional },
           namespaces: new[] { "FashionShop.Controllers" }
             );

            routes.MapRoute(
               name: "Contact",
               url: "contact",
               defaults: new { controller = "Shop", action = "Contact", id = UrlParameter.Optional }
           );

            routes.MapRoute(
               name: "Checkout",
               url: "checkout",
               defaults: new { controller = "Shop", action = "Checkout", id = UrlParameter.Optional }
           );

            #endregion

            routes.MapRoute(
               name: "Register",
               url: "user/register",
               defaults: new { controller = "User", action = "Register", id = UrlParameter.Optional },
               namespaces: new[] { "FashionShop.Controllers" }
           );

            routes.MapRoute(
               name: "UserLogin",
               url: "user/login",
               defaults: new { controller = "User", action = "Login", id = UrlParameter.Optional },
               namespaces: new[] { "FashionShop.Controllers" }
           );

            routes.MapRoute(
               name: "UserLogOut",
               url: "user/logout",
               defaults: new { controller = "User", action = "LogOut", id = UrlParameter.Optional },
               namespaces: new[] { "FashionShop.Controllers" }
           );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
