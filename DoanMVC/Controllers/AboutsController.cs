using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.DAO;

namespace DoanMVC.Controllers
{
    public class AboutsController : Controller
    {
        // GET: Abouts
        public ActionResult About()
        {
            return View();
        }
        public ActionResult gioithieu()
        {
            var item = new AboutDao().about(1);
            return PartialView();
        }
    }
}