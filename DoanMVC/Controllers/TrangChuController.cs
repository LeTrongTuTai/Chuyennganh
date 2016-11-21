using Model.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoanMVC.Controllers
{
    public class TrangChuController : Controller
    {
        // GET: TrangChu
        public ActionResult Index()
        {
            var ProductDao = new ProductDao();
            ViewBag.Logos = new LogoDao().ListAll();
            ViewBag.ContentNew = new ContentDao().newContent(2);
            return View();
        }
        [ChildActionOnly]
        //[OutputCache(Duration = 3600 * 24)]
        public ActionResult MainMenu()
        {
            var model = new MenuDao().ListByGroupId(1);
            return PartialView(model);
        }
        [ChildActionOnly]
        //[OutputCache(Duration = 3600 * 24)]
        public ActionResult TopMenu()
        {
            var model = new MenuDao().ListByGroupId(2);
            return PartialView(model);
        }
        [ChildActionOnly]
        [OutputCache(Duration = 3600 * 24)]
        public ActionResult Footer()
        {
            var model = new FooterDao().GetFooter();
            return PartialView(model);
        }
        [ChildActionOnly]
        public PartialViewResult ProductHot()
        {
            var model = new ProductDao().TopHot(8);
            return PartialView(model);
        }
        [ChildActionOnly]
        public PartialViewResult ProductNew()
        {
            var model = new ProductDao().NewProduct(8);
            return PartialView(model);
        }
        [ChildActionOnly]
        public PartialViewResult ProductBest()
        {
            var model = new ProductDao().BuyBestProduct(8);
            return PartialView(model);
        }
        [ChildActionOnly]
        public ActionResult MainSlides()
        {
            var model = new SlidesDao().ListByGroupId(1);
            return PartialView(model);
        }
        [ChildActionOnly]
        public ActionResult BotSlides()
        {
            var model = new SlidesDao().ListByGroupId(2);
            return PartialView(model);
        }
    }
}