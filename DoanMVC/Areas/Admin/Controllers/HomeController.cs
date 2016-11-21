using Model.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoanMVC.Areas.Admin.Controllers
{
    public class HomeController : BaseController
    {
        // GET: Admin/Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Order()
        {
            var model = new OrderDao().ListAll();
            return PartialView(model);
        }
    }
}