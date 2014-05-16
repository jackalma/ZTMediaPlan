using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZT.Framework.Common;
using Newtonsoft.Json;
using ZT.MediaPlan.Logics;
using ZT.MediaPlan.Enums;
using ZT.Permission;

namespace ZT.MediaPlan.Controllers.Users
{
    public class UsersController : Controller
    {       
        //
        // GET: /Users/        
        
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            return View();
        }

        /// <summary>
        /// 获取用户编号
        /// </summary>
        /// <returns></returns>
        public JsonResult GetUserId()
        {
            IUserService us = UserEngine.GetProvider<IUserService>();
            var num = us.GetUserId();            

            return Json(
                new
                {
                    num
                }
                , JsonRequestBehavior.AllowGet
            );
        }

        public string GetDirectUser()
        {
            IUserService us = UserEngine.GetProvider<IUserService>();
            List<ZT.Permission.Models.Users> listUser = us.GetDirectUser();
           
            return Newtonsoft.Json.JsonConvert.SerializeObject(listUser.Select(u => new
            {
                UserId = u.UserId,
                UserName = u.UserName,
                Position = EnumManage.JobTitle(u.JobTitle),
                Department = EnumManage.Dept(u.DeptId)
            }));
        }

        public JsonResult UserList()
        {
            IUserService us = UserEngine.GetProvider<IUserService>();
            us.GetAllUser(Permission.Enums.AccountStatusEnum.Active);
    
            List<CustomerInfo> listCustomer = new List<CustomerInfo>();

            for (int i = 1; i < 280; i++)
            {
                CustomerInfo cusInfo = new CustomerInfo();
                cusInfo.Id = Guid.NewGuid().ToString("N").ToUpper();
                cusInfo.CustomerNo = string.Format("000{0}", i.ToString());
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
                        select new { u.Id, u.CustomerNo, u.ShortName, u.CustomerType, u.CreateTime, u.ReceiptType, u.Creator, u.BusinessLicNo, u.OpenBank, u.Status }
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

        /// <summary>
        /// 创建用户
        /// </summary>
        /// <param name="jsonBase">用户基本信息</param>
        /// <param name="jsonLogin">用户登录信息</param>
        /// <returns></returns>
        public JsonResult CreateUser(string jsonBase, string jsonLogin)
        {           
            IUserService us = UserEngine.GetProvider<IUserService>();
            var value = us.CreateUser(jsonBase, jsonLogin);

            return Json(new { value });
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

        //
        // GET: /Users/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Users/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Users/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /Users/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Users/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Users/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Users/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
