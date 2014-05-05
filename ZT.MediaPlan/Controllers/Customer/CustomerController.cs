
//客户管理模块

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ZT.MediaPlan.Controllers.Customer
{
    public class CustomerController : Controller
    {
        //
        // GET: /Customer/
        public JsonResult List()
        {

            var ss = new { firstname = "FI-SW-01", lastname = "Koi", phone = "18616396346", email = "12324@126.com" };
             
                     

            return Json(ss,JsonRequestBehavior.AllowGet);
        }

        public ActionResult Create()
        {
            return View();
        }


        public ActionResult Index()
        {
            return View();
        }

    }
}
