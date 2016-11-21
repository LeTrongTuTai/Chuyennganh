using Model.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.EF;
using DoanMVC.Models;
using AutoMapper;
using DoanMVC.Common;
using Common;

namespace DoanMVC.Areas.Admin.Controllers
{
    public class UserGroupController : BaseController
    {
        private UserGroupDao _userGrDao = new UserGroupDao();

        // GET: Admin/UserGroup
        [HasCredential(RoleID = "VIEW_USERGROUP")]
        public ActionResult Index()
        {
            var result = _userGrDao.GetAll();
            return View(result);
        }

        [HasCredential(RoleID = "ADD_USERGROUP")]
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Role = _userGrDao.ListAllRole();
            return View();
        }

        [HasCredential(RoleID = "ADD_USERGROUP")]
        [HttpPost]
        public ActionResult Create(UserGroupViewModel model)
        {
            ViewBag.Role = _userGrDao.ListAllRole();
            try
            {
                if (ModelState.IsValid)
                {
                    var userGr = new USERGROUP();
                    userGr.ID = StringHelper.ToUnsignString(model.Name);
                    userGr.Name = model.Name;
                    int id = _userGrDao.Insert(userGr);

                    if (id == -1)
                    {
                        ModelState.AddModelError("", "Tên đã tồn tại");
                    }
                    else if (id == 1)
                    {
                        new CredentialDao().Create(userGr, model.Role);
                        SetAlert("Thêm thành công", "success");
                        return RedirectToAction("Index", "UserGroup");
                    }
                    else
                        ModelState.AddModelError("", "Thêm thất bại");
                }
                return View(model);
            }
            catch
            { return View(); }
        }

        [HasCredential(RoleID = "EDIT_USERGROUP")]
        [HttpGet]
        public ActionResult Edit(string id)
        {
            ViewBag.Role = _userGrDao.ListAllRole();
            string _credential = null;
            foreach (var credential in _userGrDao.GetCredentialByUserGroupID(id))
            {
                _credential += credential.RoleID + ",";
            }
            ViewBag.Credentail = _credential;
            var user = _userGrDao.ViewDetail(id);
            var res = Mapper.Map<USERGROUP, UserGroupViewModel>(user);
            return View(res);
        }

        [HasCredential(RoleID = "EDIT_USERGROUP")]
        [HttpPost]
        public ActionResult Edit(UserGroupViewModel model)
        {
            ViewBag.Role = _userGrDao.ListAllRole();
            if (ModelState.IsValid)
            {
                var userGr = new USERGROUP();
                userGr.ID = model.ID;
                userGr.Name = model.Name;
                var result = _userGrDao.Update(userGr);

                if (result == -1)
                {
                    ModelState.AddModelError("", "Tên đã tồn tại");
                }
                else if (result == 1)
                {
                    new CredentialDao().Update(userGr, model.Role);
                    SetAlert("Cập nhật thành công", "success");
                    return RedirectToAction("Index", "UserGroup");
                }
                else
                    ModelState.AddModelError("", "Cập nhật thất bại");
            }
            return View(model);
        }

        [HasCredential(RoleID = "DELETE_USERGROUP")]
        [HttpGet]
        public ActionResult Delete(string id)
        {
            var result = _userGrDao.ViewDetail(id);
            return View(result);
        }

        [HasCredential(RoleID = "DELETE_USERGROUP")]
        [HttpPost]
        public ActionResult Delete(string id, FormCollection collection)
        {
            var result = _userGrDao.Delete(id);
            if (result)
            {
                SetAlert("Xóa thành công", "success");
                return RedirectToAction("Index", "UserGroup");
            }
            else
            {
                ViewData["Error"] = "Xóa thất bại!";
                var model = _userGrDao.ViewDetail(id);
                return View(model);
            }
        }
    }
}