﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IntegrationTool.Controllers
{
    public class ErrorsController : Controller
    {
        [HttpGet]
        public ActionResult forbidden()
        {
            return View();
        }

    }
}