using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IntegrationTool.Controllers
{
    public class MainController : Controller
    {
        [HttpGet]
        public ActionResult index()
        {
            return View();
        }

    }
}
