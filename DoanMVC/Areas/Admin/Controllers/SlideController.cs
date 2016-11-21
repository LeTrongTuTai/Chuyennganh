using Model.DAO;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoanMVC.Areas.Admin.Controllers
{
    public class SlideController : BaseController
    {
        // GET: Admin/Slide
        [HasCredential(RoleID = "VIEW_SLIDE")]
        public ActionResult Index()
        {
            var model = new SlidesDao().GetAll();
            return View(model);
        }

        [HasCredential(RoleID = "EDIT_SLIDE")]
        [HttpPost]
        public JsonResult ChangeStatus(int id)
        {
            var result = new SlidesDao().ChangeStatus(id);
            return Json(new
            {
                status = result
            });
        }

        [HasCredential(RoleID = "DELETE_SLIDE")]
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new SlidesDao().Delete(id);

            return RedirectToAction("Index");
        }

        [HasCredential(RoleID = "ADD_SLIDE")]
        [HttpGet]
        public ActionResult Create()
        {
            SetViewBag();
            return View();
        }

        [HasCredential(RoleID = "ADD_SLIDE")]
        [HttpPost]
        public ActionResult Create(SLIDE model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var dao = new SlidesDao();
                    int id = dao.Insert(model);
                    if (id > 0)
                    {
                        SetAlert("Thêm thành công", "success");
                        return RedirectToAction("Index", "Slide");
                    }
                    else
                        ModelState.AddModelError("", "Thêm thất bại");
                }
                SetViewBag(model.ID);
                return View(model);
            }
            catch
            {
                return View();
            }
        }

        [HasCredential(RoleID = "EDIT_SLIDE")]
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var result = new SlidesDao().GetById(id);
            SetViewBag();
            return View(result);
        }

        [HasCredential(RoleID = "EDIT_SLIDE")]
        [HttpPost]
        public ActionResult Edit(SLIDE model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = new SlidesDao().Update(model);
                    if (result)
                    {
                        SetAlert("Cập nhật thành công", "success");
                        return RedirectToAction("Index", "Slide");
                    }
                    else
                        ModelState.AddModelError("", "Cập nhật thất bại");
                }
                SetViewBag(model.ID);
                return View(model);
            }
            catch
            { return View(); }
        }
        public void SetViewBag(int selectedId = 0)
        {
            var dao = new SlideGroupDao();
            ViewBag.GroupID = new SelectList(dao.ListAll(), "ID","TypeID", selectedId);
        }
    }
}