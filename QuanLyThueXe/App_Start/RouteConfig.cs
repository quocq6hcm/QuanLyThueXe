using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace QuanLyThueXe
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "DangNhap",
                url: "Admin/Login",
                defaults: new { controller = "TaiKhoan", action = "Login", id = UrlParameter.Optional }
            );
            routes.MapRoute(
               name: "Index",
               url: "Home/MenuLichTheoNgay",
               defaults: new { controller = "Home", action = "MenuLichTheoNgay", id = UrlParameter.Optional }
           );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "MenuLichTheoNgay", id = UrlParameter.Optional }
            //defaults: new { controller = "Home", action = "TestingSite", id = UrlParameter.Optional }
            );
        }
    }
}
