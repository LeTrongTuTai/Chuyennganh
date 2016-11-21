using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.DAO;
using Model.EF;
using Common;
using DoanMVC.Common;

namespace DoanMVC.Areas.Admin.Controllers
{
    public class ProductController : BaseController
    {
        // GET: Admin/Content
        [HasCredential(RoleID = "VIEW_PRODUCT")]
        public ActionResult Index(string searchString, int page = 1, int pageSize = 3)
        {
            var dao = new SanphamDao();
            var model = dao.ListAllPaging(searchString, page, pageSize);

            ViewBag.SearchString = searchString;
            return View(model);
        }
        [HttpGet]
        [HasCredential(RoleID = "ADD_PRODUCT")]
        [ValidateInput(false)]
        public ActionResult Create()
        {
            SetViewBag();
            return View();
        }
        [HttpGet]
        [HasCredential(RoleID = "EDIT_PRODUCT")]
        public ActionResult Edit(long id)
        {
            var dao = new SanphamDao();
            var product = dao.GetByID(id);

            SetViewBag(product.ID);

            return View(product);
        }
        [HttpPost]
        [HasCredential(RoleID = "EDIT_PRODUCT")]
        [ValidateInput(false)]
        public ActionResult Edit(PRODUCT model)
        {
            if (ModelState.IsValid)
            {
                if (model.PromotionPrice >= model.Price)
                {
                    ModelState.AddModelError("", "Vui lòng kiểm tra lại giá khuyến mãi.");
                }
                else
                {
                    if (ModelState.IsValid)
                    {
                        var product = new SanphamDao();
                        var result = product.Update(model);
                        if (result)
                        {
                            SetAlert("Cập nhật thành công", "success");
                            return RedirectToAction("Index", "Product");
                        }
                        else
                        {
                            ModelState.AddModelError("", "Cập nhật thất bại");
                        }
                    }
                }
            }
            SetViewBag(model.ID);
            return View(model);

        }

        [HttpPost]
        [HasCredential(RoleID = "ADD_PRODUCT")]
        [ValidateInput(false)]
        public ActionResult Create(PRODUCT model)
        {
            if (ModelState.IsValid)
            {
                var dao = new SanphamDao();
                long id = dao.Insert(model);
                if (id > 0)
                {
                    SetAlert("Thêm sản phẩm thành công", "success");
                    return RedirectToAction("Index", "Product");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm sản phẩm không thành công");
                }
            }
            SetViewBag(model.ID);
            return View("Index");

        }

        public void SetViewBag(long? selectedId = null)
        {
            var dao = new SanphamDao();
            ViewBag.ID = new SelectList(dao.ListAll(), "ID", "Name", selectedId);
        }
        [HttpDelete]
        [HasCredential(RoleID = "DELETE_PRODUCT")]
        public ActionResult Delete(int id)
        {
            new SanphamDao().Delete(id);

            return RedirectToAction("Index");
        }
        [HttpPost]
        [HasCredential(RoleID = "EDIT_PRODUCT")]
        public JsonResult ChangeStatus(long id)
        {
            var result = new SanphamDao().ChangeStatus(id);
            return Json(new
            {
                status = result
            });
        }
        //[HasCredential(RoleID = "EDIT_PRODUCT")]
        //public JsonResult SaveImages(int id, string images)
        //{
        //    var listImages = images.Replace(ConfigHelper.GetByKey("CurrentLink"), "/");

        //    var dao = new SanphamDao();
        //    try
        //    {
        //        dao.UpdateImages(id, listImages);
        //        return Json(new
        //        {
        //            status = true
        //        });
        //    }
        //    catch (Exception)
        //    {
        //        return Json(new
        //        {
        //            status = false
        //        });
        //    }
        //}

    }
}