using Model.DAO;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoanMVC.Areas.Admin.Controllers
{
    public class LogoController : BaseController
    {
        // GET: Admin/Logo
        [HasCredential(RoleID = "VIEW_LOGO")]
        public ActionResult Index()
        {
            var model = new LogoDao().GetAll();
            return View(model);
        }

        [HasCredential(RoleID = "EDIT_LOGO")]
        [HttpPost]
        public JsonResult ChangeStatus(int id)
        {
            var result = new LogoDao().ChangeStatus(id);
            return Json(new
            {
                status = result
            });
        }

        [HasCredential(RoleID = "DELETE_LOGO")]
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new LogoDao().Delete(id);

            return RedirectToAction("Index");
        }

        [HasCredential(RoleID = "ADD_LOGO")]
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HasCredential(RoleID = "ADD_LOGO")]
        [HttpPost]
        public ActionResult Create(LOGO model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var dao = new LogoDao();
                    int id = dao.Insert(model);
                    if (id > 0)
                    {
                        SetAlert("Thêm thành công", "success");
                        return RedirectToAction("Index", "Logo");
                    }
                    else
                        ModelState.AddModelError("", "Thêm thất bại");
                }
                return View(model);
            }
            catch
            {
                return View();
            }
        }

        [HasCredential(RoleID = "EDIT_LOGO")]
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var result = new LogoDao().GetById(id);
            return View(result);
        }

        [HasCredential(RoleID = "EDIT_LOGO")]
        [HttpPost]
        public ActionResult Edit(LOGO model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = new LogoDao().Update(model);
                    if (result)
                    {
                        SetAlert("Cập nhật thành công", "success");
                        return RedirectToAction("Index", "Logo");
                    }
                    else
                        ModelState.AddModelError("", "Cập nhật thất bại");
                }
                return View(model);
            }
            catch
            { return View(); }
        }
    }
}