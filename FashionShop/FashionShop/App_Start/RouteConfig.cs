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
               name: "Contact",
               url: "contact",
               defaults: new { controller = "Shop", action = "Contact", id = UrlParameter.Optional }
           );
            #endregion

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
