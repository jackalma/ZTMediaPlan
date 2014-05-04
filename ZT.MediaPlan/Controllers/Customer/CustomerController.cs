
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
            return Json(new
            {
                a = "这是客户管理"

            });
        }

        public JsonResult Create()
        {
            return Json(new
            {
                a = "创建客户"
            });
        }


        public ActionResult Index()
        {
            return View();
        }

    }
}
