using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace DoanMVC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.IgnoreRoute("{*botdetect}",
      new { botdetect = @"(.*)BotDetectCaptcha\.ashx" });

            routes.MapRoute(
                name: "Product Detail",
                url: "chi-tiet/{metatitle}-{id}.html",
                defaults: new { controller = "Produc", action = "Detail", id = UrlParameter.Optional },
                namespaces: new[] { "DoanMVC.Controllers" }
            );
            routes.MapRoute(
                name: "Gioi thieu",
                url: "gioi-thieu.html",
                defaults: new { controller = "Abouts", action = "About", id = UrlParameter.Optional },
                namespaces: new[] { "DoanMVC.Controllers" }
            );
            routes.MapRoute(
               name: "Tintuc Detail",
               url: "tin-tuc/{metatitle}-{id}.html",
               defaults: new { controller = "Blogs", action = "DetailBlogs", id = UrlParameter.Optional },
               namespaces: new[] { "DoanMVC.Controllers" }
           );
            routes.MapRoute(
                name: "Product",
                url: "san-pham.html",
                defaults: new { controller = "Produc", action = "Product", id = UrlParameter.Optional },
                namespaces: new[] { "DoanMVC.Controllers" }
            );
            routes.MapRoute(
                name: "Timkiem",
                url: "tim-kiem.html",
                defaults: new { controller = "Produc", action = "Search", id = UrlParameter.Optional },
                namespaces: new[] { "DoanMVC.Controllers" }
            );
            routes.MapRoute(
               name: "Blogs",
               url: "tin-tuc.html",
               defaults: new { controller = "Blogs", action = "Index", id = UrlParameter.Optional },
               namespaces: new[] { "DoanMVC.Controllers" }
           );

            routes.MapRoute(
               name: "Contact",
               url: "lien-he.html",
               defaults: new { controller = "Contact", action = "Lienhe", id = UrlParameter.Optional },
               namespaces: new[] { "DoanMVC.Controllers" }
           );

            routes.MapRoute(
               name: "Register",
               url: "tao-tai-khoan.html",
               defaults: new { controller = "Account", action = "Register", id = UrlParameter.Optional },
               namespaces: new[] { "DoanMVC.Controllers" }
           );
            routes.MapRoute(
               name: "LoginUser",
               url: "dang-nhap.html",
               defaults: new { controller = "Account", action = "Login", id = UrlParameter.Optional },
               namespaces: new[] { "DoanMVC.Controllers" }
           );

            routes.MapRoute(
                name: "Productcategory",
                url: "san-pham/{metatitle}-{id}.html",
                defaults: new { controller = "Produc", action = "Category", id = UrlParameter.Optional },
                namespaces: new[] { "DoanMVC.Controllers" }
            );

            routes.MapRoute(
                name: "ProductBanChay",
                url: "san-pham-ban-chay.html",
                defaults: new { controller = "Produc", action = "ProductBanChay", id = UrlParameter.Optional },
                namespaces: new[] { "DoanMVC.Controllers" }
            );
            routes.MapRoute(
                name: "ProductMoi",
                url: "san-pham-moi.html",
                defaults: new { controller = "Produc", action = "ProductMoi", id = UrlParameter.Optional },
                namespaces: new[] { "DoanMVC.Controllers" }
            );
            routes.MapRoute(
                name: "ProductView",
                url: "san-pham-xem-nhieu-nhat.html",
                defaults: new { controller = "Produc", action = "ProductView", id = UrlParameter.Optional },
                namespaces: new[] { "DoanMVC.Controllers" }
            );
            routes.MapRoute(
                name: "ProductSale",
                url: "san-pham-khuyen-mai.html",
                defaults: new { controller = "Produc", action = "ProductSale", id = UrlParameter.Optional },
                namespaces: new[] { "DoanMVC.Controllers" }
            );
            routes.MapRoute(
                name: "Cart",
                url: "gio-hang.html",
                defaults: new { controller = "Carts", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "DoanMVC.Controllers" }
            );
            routes.MapRoute(
                name: "Add cart",
                url: "them-gio-hang.html",
                defaults: new { controller = "Carts", action = "AddItem", id = UrlParameter.Optional },
                namespaces: new[] { "DoanMVC.Controllers" }
            );
            routes.MapRoute(
                name: "Payment",
                url: "thanh-toan.html",
                defaults: new { controller = "Carts", action = "Payment", id = UrlParameter.Optional },
                namespaces: new[] { "DoanMVC.Controllers" }
            );
            routes.MapRoute(
                name: "Payment Success",
                url: "hoan-thanh.html",
                defaults: new { controller = "Carts", action = "Success", id = UrlParameter.Optional },
                namespaces: new[] { "DoanMVC.Controllers" }
            );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "TrangChu", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "DoanMVC.Controllers" }
            );
        }
    }
}
