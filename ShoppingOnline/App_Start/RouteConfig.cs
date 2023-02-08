 using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ShoppingOnline
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "ProductCategory",
                url: "chi-tiet/{metatitle}-{id}",
                defaults: new { controller = "Product", action = "ProductDetail", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "CategoryDetail",
                url: "san-pham/{metatitle}-{id}",
                defaults: new { controller = "Product", action = "CategoryDetail", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
