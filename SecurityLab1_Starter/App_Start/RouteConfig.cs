using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SecurityLab1_Starter
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            routes.MapRoute(
             name: "EmptyUrl",
             url: "",
             defaults: new { controller = "Home", action = "Index" }
         );
            routes.MapRoute(
                  name: "Inventory",
                  url: "Inventory/Index",
                  defaults: new { controller = "Inventory", action = "Index", id = UrlParameter.Optional }
);
            routes.MapRoute(
             name: "ServerError",
             url: "Error/ServerError",
             defaults: new { controller = "Error", action = "ServerError" }
         );

            ;
            routes.MapRoute(
                  name: "Home",
                  url: "Home/{action}",
                  defaults: new { controller = "Home", action = "Index" },
                  constraints: new { action = "Index|Contact|About|GenError|Account" }
);
            /*            routes.MapRoute(
                            name: "CatchAllRoute",
                            url: "{*url}",
                            defaults: new { controller = "Error", action = "NotFound", id = UrlParameter.Optional }
                        );*/
            routes.MapRoute(
                name: "Account",
                url: "Account/{action}/{id}",
                defaults: new { controller = "Account", action = "Login", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Login",
                url: "Account/Login",
                defaults: new { controller = "Account", action = "Login" }
            );

        }
    }
}
