using Model.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoanMVC.Areas.Admin.Controllers
{
    public class feedbackController : BaseController
    {
        // GET: Admin/feedback
        [HasCredential(RoleID = "VIEW_FEEDBACK")]
        public ActionResult Index()
        {
            var model = new FeedbackDao().ListAll();
            return View(model);
        }

        [HasCredential(RoleID = "EDIT_FEEDBACK")]
        [HttpPost]
        public JsonResult ChangeStatus(int id)
        {
            var result = new FeedbackDao().ChangeStatus(id);
            return Json(new
            {
                status = result
            });
        }

        [HasCredential(RoleID = "DELETE_FEEDBACK")]
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new FeedbackDao().Delete(id);
            return RedirectToAction("Index");
        }

        [HasCredential(RoleID = "DETAIL_FEEDBACK")]
        public ActionResult Detail(int id)
        {
            var result = new FeedbackDao().GetById(id);
            return View(result);
        }
    }
}