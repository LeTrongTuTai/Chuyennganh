using Model.DAO;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoanMVC.Areas.Admin.Controllers
{
    public class ContactController : BaseController
    {
        // GET: Admin/Contact
        [HasCredential(RoleID = "VIEW_CONTACT")]
        public ActionResult Index()
        {
            var model = new ContactDao().GetContact();
            return View(model);
        }

        [HasCredential(RoleID = "EDIT_CONTACT")]
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = new ContactDao().GetById(id);
            return View(model);
        }

        [HasCredential(RoleID = "EDIT_CONTACT")]
        [HttpPost]
        public ActionResult Edit(CONTACT model)
        {
            if (ModelState.IsValid)
            {
                var dao = new ContactDao();

                var result = dao.Update(model);
                if (result)
                {
                    SetAlert("Sửa thành công", "success");
                    return RedirectToAction("Index", "Content");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật không thành công");
                }
            }
            return View("Index");
        }
        [HttpPost]
        [HasCredential(RoleID = "EDIT_CONTACT")]
        public JsonResult ChangeStatus(long id)
        {
            var result = new ContactDao().ChangeStatus(id);
            return Json(new
            {
                status = result
            });
        }
    }
}