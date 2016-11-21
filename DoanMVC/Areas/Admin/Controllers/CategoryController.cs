using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoanMVC.Common;
using Model.DAO;
using Model.EF;
using BotDetect;
using System.Web.Script.Serialization;

namespace DoanMVC.Areas.Admin.Controllers
{
    public class CategoryController : BaseController
    {
        // GET: Admin/Category
        [HasCredential(RoleID = "VIEW_CATEGORY")]
        public ActionResult Index(string searchString, int page = 1, int pageSize = 3)
        {
            var dao = new CategoryDao();
            var model = dao.ListAllPaging(searchString, page, pageSize);

            ViewBag.SearchString = searchString;
            return View(model);
        }
        [HttpGet]
        [HasCredential(RoleID = "ADD_CATEGORY")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [HasCredential(RoleID = "ADD_CATEGORY")]
        public ActionResult Create(CATEGORY model)
        {
            if (ModelState.IsValid)
            {
                var currentCulture = Session[CommonConstants.CurrentCulture];
                model.Language = currentCulture.ToString();
                var id = new CategoryDao().Insert(model);
                if (id > 0)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", StaticResources.Resources.InsertCategoryFailed);
                }
            }
            return View(model);
        }
        [HasCredential(RoleID = "EDIT_CATEGORY")]
        public ActionResult Edit(long id)
        {
            var category = new CategoryDao().ViewDetailCategory(id);
            return View(category);
        }
        [HttpPost]
        [HasCredential(RoleID = "EDIT_CATEGORY")]
        public ActionResult Edit(CATEGORY category)
        {
            if (ModelState.IsValid)
            {
                var dao = new CategoryDao();
                var result = dao.Update(category);
                if (result)
                {
                    SetAlert("Sửa danh mục thành công", "success");
                    return RedirectToAction("Index", "Category");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật danh mục không thành công");
                }
            }
            return View("Index");
        }

        [HttpDelete]
        [HasCredential(RoleID = "DELETE_CATEGORY")]
        public ActionResult Delete(int id)
        {
            new CategoryDao().Delete(id);

            return RedirectToAction("Index");
        }
        [HttpPost]
        [HasCredential(RoleID = "EDIT_CATEGORY")]
        public JsonResult ChangeStatus(long id)
        {
            var result = new CategoryDao().ChangeStatus(id);
            return Json(new
            {
                status = result
            });
        }
    }
}