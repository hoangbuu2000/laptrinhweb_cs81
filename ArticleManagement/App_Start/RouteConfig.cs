using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ArticleManagement
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "ChiTietTinTuc",
                "tintuc/details/{id}",
                new { controller = "Articles", action = "Details" },
                new { id = @"\d+" }
            );

            routes.MapRoute(
                "DanhMuc",
                "tintuc/danhmuc/{id}",
                new { controller = "Home", action = "Index" },
                new { id = @"\d+" }
            );

            routes.MapRoute(
                "TrangChu",
                "",
                new { controller = "Home", action = "Index" }
            );

            routes.MapRoute(
                "Default",
                "{controller}/{action}/{id}",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
