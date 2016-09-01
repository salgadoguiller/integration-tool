using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IntegrationTool.Controllers
{
    public class ConfigurationController : Controller
    {
        public ActionResult activedirectory()
        {
            return View();
        }

        public ActionResult serversmtp()
        {
            return View();
        }

        public ActionResult database()
        {
            return View();
        }

    }
}
