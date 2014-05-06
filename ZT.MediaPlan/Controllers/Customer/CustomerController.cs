
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
        }
        public JsonResult CustomerList()
        {
            List<AAA> page = new List<AAA>();
            AAA aa = new AAA();
            aa.firstname = "asdfasdf";
            aa.lastname = "asdfasd";
            aa.phone = "2131232131";
            aa.email = "12312@126.com";
            page.Add(aa);

            AAA aa2 = new AAA();
            aa2.firstname = "asdfasdf";
            aa2.lastname = "asdfasd";
            aa2.phone = "2131232131";
            aa2.email = "12312@126.com";
            page.Add(aa2);            

            var data = from u in page
                       select new { u.firstname, u.lastname, u.phone, u.email };

            var result = new { total = page.Count(), rows = data };

            return Json(result, JsonRequestBehavior.AllowGet);
            
        }
       
        public class AAA {
            public string firstname { get; set; }
            public string lastname { get; set; }
            public string phone { get; set; }
            public string email { get; set; }
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
