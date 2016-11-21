using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.DAO;
using Model.EF;
using System.Web.Script.Serialization;

namespace DoanMVC.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        public ActionResult Lienhe()
        {
            var model = new ContactDao().GetActiveContact();
            return View(model);
        }
        [HttpPost]
        public JsonResult Send(string feebackViewModel)
        {
            var feebackVm = new JavaScriptSerializer().Deserialize<FEEDBACK>(feebackViewModel);
            feebackVm.CreatedDate = DateTime.Now;                 
            var id = new ContactDao().InsertFeedBack(feebackVm);
            if (id > 0)
            {
                return Json(new
                {
                    status = true
                });
                //send mail
            }

            else
                return Json(new
                {
                    status = false
                });

        }
    }
}