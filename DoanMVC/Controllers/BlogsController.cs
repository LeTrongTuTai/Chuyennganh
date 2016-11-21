using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.DAO;

namespace DoanMVC.Controllers
{
    public class BlogsController : Controller
    {
        // GET: Blogs
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ContentCategory()
        {
            var mode = new ContentDao().newContent(5);
            return PartialView(mode);
        }
        public ActionResult Blogs()
        {
            var mode = new ContentDao().newContent(5);
            return PartialView(mode);
        }
        public ActionResult DetailBlogs(long id)
        {
            var mode = new ContentDao().ViewDetail(id);
            return View(mode);
        }
    }
}