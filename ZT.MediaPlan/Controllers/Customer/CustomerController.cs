
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

        private String rows;//每页显示的记录数  

        private String page;//当前第几页  

        public String getRows()
        {
            return rows;
        }
        public void setRows(String rows)
        {
            this.rows = rows;
        }
        public String getPage()
        {
            return page;
        }
        public void setPage(String page)
        {
            this.page = page;
        }  

        public JsonResult CustomerList()
        {
            var ss = page;
            var bb = rows;

            List<CustomerInfo> listCustomer = new List<CustomerInfo>();

            for (int i = 1; i < 280; i++)
            {
                CustomerInfo cusInfo = new CustomerInfo();
                cusInfo.CustomerNo = string.Format("000{0}",i.ToString ());
                cusInfo.CustomerName = string.Format("中天广告传媒{0}", i);
                cusInfo.CustomerType = "4A";
                cusInfo.CreateTime = DateTime.Now.ToString("yyyy-MM-dd hh-mm-ss");
                cusInfo.ReceiptType = "发票";
                cusInfo.Creator = "张三";
                cusInfo.BusinessLicNo = string.Format("N093827{0}", i);
                cusInfo.Bank = "中国银行";
                cusInfo.Status = "1";

                listCustomer.Add(cusInfo);
            }
           
            var data = from u in listCustomer
                       select new { u.CustomerNo, u.CustomerName, u.CustomerType, u.CreateTime, u.ReceiptType, u.Creator, u.BusinessLicNo, u.Bank, u.Status };
            
                        
            var result = new { total = listCustomer.Count(), rows = data };

            return Json(result, JsonRequestBehavior.AllowGet);
            
        }

        public class CustomerInfo
        {
            public string CustomerNo { get; set; }
            public string CustomerName { get; set; }
            public string CustomerType { get; set; }
            public string CreateTime { get; set; }
            public string ReceiptType { get; set; }
            public string Creator { get; set; }
            public string BusinessLicNo { get; set; }
            public string Bank { get; set; }
            public string Status { get; set; }
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
