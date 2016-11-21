using DoanMVC.Common;
using Model.DAO;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace DoanMVC.Areas.Admin.Controllers
{
    public class ContentController : BaseController
    {
        // GET: Admin/Content
        [HasCredential(RoleID = "VIEW_CONTENT")]
        public ActionResult Index(string searchString, int page = 1, int pageSize = 3)
        {
            var dao = new ContentDao();
            var model = dao.ListAllPaging(searchString, page, pageSize);

            ViewBag.SearchString = searchString;
            return View(model);
        }
        [HttpGet]
        [HasCredential(RoleID = "ADD_CONTENT")]
        public ActionResult Create()
        {
            SetViewBag();
            return View();
        }
     
        [HttpGet]
        [HasCredential(RoleID = "EDIT_CONTENT")]
        public ActionResult Edit(long id)
        {
            var dao = new ContentDao();
            var content = dao.GetByID(id);

            SetViewBag(content.ID);

            return View(content);
        }
        [ValidateInput(false)]
        [HttpPost]
        [HasCredential(RoleID = "EDIT_CONTENT")]
        public ActionResult Edit(CONTENT content)
        {
            if (ModelState.IsValid)
            {
                var dao = new ContentDao();
                
                var result = dao.Update(content);
                if (result)
                {
                    SetAlert("Sửa tin tức thành công", "success");
                    return RedirectToAction("Index", "Content");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật tin tức không thành công");
                }

            }
            SetViewBag(content.ID);
            return View("Index");

        }

        [HttpPost]
        [HasCredential(RoleID = "ADD_CONTENT")]
        [ValidateInput(false)]
        public ActionResult Create(CONTENT model)
        {
            if (ModelState.IsValid)
            {
                var dao = new ContentDao();
                long id = dao.Insert(model);
                if (id > 0)
                {
                    SetAlert("Thêm tin tức thành công", "success");
                    return RedirectToAction("Index", "Content");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm tin tức không thành công");
                }
            }
            SetViewBag(model.ID);
            return View("Index");

        }

        public void SetViewBag(long? selectedId = null)
        {
            var dao = new CategoryDao();
            ViewBag.CategoryID = new SelectList(dao.ListAll(), "ID", "Name", selectedId);
        }
        [HttpDelete]
        [HasCredential(RoleID = "DELETE_CONTENT")]
        public ActionResult Delete(int id)
        {
            new ContentDao().Delete(id);

            return RedirectToAction("Index");
        }
        [HttpPost]
        [HasCredential(RoleID = "EDIT_CONTENT")]
        public JsonResult ChangeStatus(long id)
        {
            var result = new ContentDao().ChangeStatus(id);
            return Json(new
            {
                status = result
            });
        }
    }
}