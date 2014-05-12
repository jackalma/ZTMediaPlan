
//客户管理模块

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZT.Framework.Common;
using Newtonsoft.Json;
using ZT.MediaPlan.Logics;
using ZT.MediaPlan.Enums;

namespace ZT.MediaPlan.Controllers.Customer
{
    public class CustomerController : Controller
    {
//        ORACLE
//--第n页
//--每页m条数据
//select *
//  from (select a.*, rownum rownum_
//          from (SELECT seq_id,last_changed,customer_name FROM mp_mediaplan order by last_changed desc) a
//         where rownum <= n*2)
//where rownum_ > n*2-m



//SQLSERVER
//第n页
//每页m条数据

//select b.*
//  from (select a.*
//          from (SELECT ROW_NUMBER() OVER(ORDER BY Last_Changed DESC) AS RowNumber,* FROM Post) a
//         where a.RowNumber <= n*2) b
//where b.RowNumber> n*2-m

        //
        // GET: /Customer/
        public ActionResult List()
        {           
            return View();
        }       
     
         //SeqNoLogic.GetCustomerNo(SeqNoEnum.CustomerNo);

        public JsonResult GetCustomerNo()
        {
            var num = SeqNoLogic.GetCustomerNo(SeqNoEnum.CustomerNo);

            return Json(
                new
                {
                    num
                }
                , JsonRequestBehavior.AllowGet
            );
        }

        public JsonResult CustomerList()
        {           
            List<CustomerInfo> listCustomer = new List<CustomerInfo>();

            for (int i = 1; i < 280; i++)
            {
                CustomerInfo cusInfo = new CustomerInfo();
                cusInfo.Id = Guid.NewGuid().ToString("N").ToUpper();
                cusInfo.CustomerNo = string.Format("000{0}",i.ToString ());
                cusInfo.ShortName = string.Format("中天广告传媒{0}", i);
                cusInfo.CustomerType = 4;
                cusInfo.CreateTime = DateTime.Now;
                cusInfo.ReceiptType = "发票";
                cusInfo.Creator = "张三";
                cusInfo.BusinessLicNo = string.Format("N093827{0}", i);
                cusInfo.OpenBank = "中国银行";
                cusInfo.Status = "1";

                listCustomer.Add(cusInfo);
            }   

            var page = GetPageIndex();
            var rows = GetPageSize();

            var data = (from u in listCustomer
                        orderby u.CreateTime
                        select new {u.Id, u.CustomerNo, u.ShortName, u.CustomerType, u.CreateTime, u.ReceiptType, u.Creator, u.BusinessLicNo, u.OpenBank, u.Status }
                       ).Skip((page - 1) * rows)
                       .Take(rows);
                                    
            //var result = new { total = listCustomer.Count(), rows = data };
            //return Json(result, JsonRequestBehavior.AllowGet);

            var a = Json(new
            {
                total = listCustomer.Count(),
                rows = data.Select(u => new
                {
                    CustomerNo = u.CustomerNo,
                    ShortName = u.ShortName,
                    CustomerType = u.CustomerType,
                    CreateTime = u.CreateTime,
                    ReceiptType = u.ReceiptType,
                    Creator = u.Creator,
                    BusinessLicNo = u.BusinessLicNo,
                    OpenBank = u.OpenBank,
                    Status = u.Status,
                    Actions = "<a href=\"javascript:checkUser('" + u.Id + "')\">查看</a>",
                })
            }, JsonRequestBehavior.AllowGet);

            return a;            
        }

        public JsonResult CreateUser(string json)
        {
            CustomerInfo ci = null;
            var _json = SystemDataProvider.GetStandardJson(json.ToString());
            ci = JsonConvert.DeserializeObject<CustomerInfo>(json);
            
            //mp.Json = JsonConvert.SerializeObject(mp.Model);

            return Json("adsfa");
        }
        



        private int GetPageIndex()
        {
            if (string.IsNullOrEmpty(this.Request.Params["page"]))
                return 1;

            return this.Request.Params["page"].ToInteger();
        }

        private int GetPageSize()
        {
            if (string.IsNullOrEmpty(this.Request.Params["rows"]))
                return 10;
            return this.Request.Params["rows"].ToInteger();
        }

        public class CustomerInfo
        {
            public string Id { get; set; }
            public string CustomerNo { get; set; }
            public string ShortName { get; set; }
            public int CustomerType { get; set; }
            public DateTime CreateTime { get; set; }
            public string ReceiptType { get; set; }
            public string Creator { get; set; }
            public string BusinessLicNo { get; set; }
            public string OpenBank { get; set; }
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
