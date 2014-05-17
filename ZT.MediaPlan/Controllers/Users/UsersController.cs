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

        /// <summary>
        /// 获取简单用户数据，用于选择直接上级
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// 用户列表
        /// </summary>
        /// <returns></returns>
        public JsonResult UserList(string deptId,string jobTitle,string status)
        {
            
            IUserService us = UserEngine.GetProvider<IUserService>();
            if (deptId == "100") deptId = "";
            if (jobTitle == "100") jobTitle = "";
            if (status == "100") status = "";

            List<Permission.Models.UsersList> listUsers = us.GetUsersList(deptId, jobTitle, status);


            var page = GetPageIndex();
            var rows = GetPageSize();

            var data = (from u in listUsers
                        orderby u.JoinDate
                        select new { u.ID, u.UserId, u.LoginName, u.UserName, u.EngName, u.Sex, u.DeptId, u.JobTitle, u.ParentName, u.JoinDate, u.LeaveDate, u.Status }
                       ).Skip((page - 1) * rows)
                       .Take(rows);

            //var result = new { total = listCustomer.Count(), rows = data };
            //return Json(result, JsonRequestBehavior.AllowGet);

            var a = Json(new
            {
                total = listUsers.Count(),
                rows = data.Select(u => new
                {
                    UserId = u.UserId,
                    LoginName = u.LoginName,
                    UserName = u.UserName,
                    EngName = u.EngName,
                    Sex = EnumManage.Sex(u.Sex),
                    Department = EnumManage.Dept(u.DeptId),
                    JobTitle = EnumManage.JobTitle(u.JobTitle),
                    DirectUser = u.ParentName,
                    JoinDate = u.JoinDate,
                    LeaveDate = u.LeaveDate,
                    Status = EnumManage.AccountStatus(u.Status),
                    Actions = "<a href=\"javascript:checkUser('" + u.ID + "')\">查看</a>",
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

        public string GetUser(string userId)
        {
            IUserService us = UserEngine.GetProvider<IUserService>();

            var value = us.GetUserInfo(userId.ToInteger());


            return Newtonsoft.Json.JsonConvert.SerializeObject(new
            {
                UserId = value.UserId,
                UserName = value.UserName,
                EngName = value.EngName,
                Sex = value.Sex,
                Age = value.Age,
                PhoneNumber = value.PhoneNumber,
                Birthday = value.Birthday,
                ICNumber = value.ICNumber,
                Address = value.Address,
                JobTitle = value.JobTitle,
                Department = value.DeptId,
                Email = value.Email,
                TaxNumber = value.TaxNumber,
                DirectUser = value.ParentId,
                JoinDate = value.JoinDate,
                LoginName = "",
                Password = ""
            });
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
