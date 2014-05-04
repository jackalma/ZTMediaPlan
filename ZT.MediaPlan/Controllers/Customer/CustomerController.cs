
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
        public ActionResult List()
        {
            return View();
            //return Json(new
            //{
            //    a = "这是客户管理"

            //}, JsonRequestBehavior.AllowGet);
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
