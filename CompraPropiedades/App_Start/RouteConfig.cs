using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CompraPropiedades
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Casas",
                url: "Casas",
                defaults: new { controller = "Home", action = "Casas", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Buscar",
                url: "Buscar",
                defaults: new { controller = "Home", action = "Buscar", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Detalle",
                url: "Detalle",
                defaults: new { controller = "Home", action = "Detalle", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Publication",
                url: "Publicacion",
                defaults: new { controller = "Home", action = "Publication", idPublicacion = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Publicar",
                url: "Publicar",
                defaults: new { controller = "Post", action = "Index", idPublicacion = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Publicar_2",
                url: "Post",
                defaults: new { controller = "Post", action = "Index", idPublicacion = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
