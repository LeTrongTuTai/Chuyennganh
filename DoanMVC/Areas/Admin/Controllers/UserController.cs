using DoanMVC.Common;
using Model.DAO;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace DoanMVC.Areas.Admin.Controllers
{
    public class UserController : BaseController
    {
        // GET: Admin/User
        [HasCredential(RoleID ="VIEW_USER")]
        public ActionResult Index(string searchString, int page = 1, int pageSize = 3)
        {
            var dao = new UserDao();
            var model =dao.ListAllPaging(searchString, page, pageSize);

            ViewBag.SearchString = searchString;
            return View(model);
        }
        [HttpGet] // tai trang giao dien
        [HasCredential(RoleID = "ADD_USER")]
        public ActionResult Create()
        {
            SetViewBag();
            return View();
        }
        [HttpPost] // font cua code len
        [HasCredential(RoleID = "ADD_USER")]
        public ActionResult Create(USER user)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();

                var encryptedMd5Pas = Encryptor.MD5Hash(user.Password);
                user.Password = encryptedMd5Pas;

                long id = dao.Insert(user);
                if (id > 0)
                {
                    SetAlert("Thêm user thành công", "success");
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm user không thành công");
                }
            }
            SetViewBag(user.GroupID);
            return View("Index");
        }
        [HasCredential(RoleID = "EDIT_USER")]
        public ActionResult Edit(int id)
        {
            var user = new UserDao().ViewDetail(id);
            SetViewBag(user.GroupID);
            return View(user);
        }
        [HttpPost]
        [HasCredential(RoleID = "EDIT_USER")]
        public ActionResult Edit(USER user)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                if (!string.IsNullOrEmpty(user.Password))
                {
                    var encryptedMd5Pas = Encryptor.MD5Hash(user.Password);
                    user.Password = encryptedMd5Pas;
                }
                var result = dao.Update(user);
                if (result)
                {
                    SetAlert("Sửa user thành công", "success");
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật user không thành công");
                }
            }
            SetViewBag(user.GroupID);
            return View("Index");
        }

        public void SetViewBag(string selectedId = null)
        {
            var dao = new UserGroupDao();
            ViewBag.GroupID = new SelectList(dao.ListAll(), "ID", "Name", selectedId);
        }

        [HttpDelete]
        [HasCredential(RoleID = "DELETE_USER")]
        public ActionResult Delete(int id)
        {
            new UserDao().Delete(id);

            return RedirectToAction("Index");
        }
        [HttpPost]
        [HasCredential(RoleID = "EDIT_USER")]
        public JsonResult ChangeStatus(long id)
        {
            var result = new UserDao().ChangeStatus(id);
            return Json(new
            {
                status = result
            });
        }

    }
}