﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ZT.MediaPlan.Controllers.Actions
{
    public class ActionsController : Controller
    {
        //
        // GET: /Actions/

        public JsonResult List()
        {
            return null;
        }

        public ActionResult Index()
        {
            return View();
        }

    }
}
