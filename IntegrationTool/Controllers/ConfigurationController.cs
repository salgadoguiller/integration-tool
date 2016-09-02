using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IntegrationTool.Controllers
{
    public class ConfigurationController : Controller
    {
        [HttpGet]
        public ActionResult activedirectory()
        {
            return View();
        }

        [HttpGet]
        public ActionResult serversmtp()
        {
            return View();
        }

        [HttpGet]
        public ActionResult databases()
        {
            return View();
        }

        [HttpGet]
        public ActionResult webservices()
        {
            return View();
        }

        [HttpGet]
        public ActionResult flatfiles()
        {
            return View();
        }

        [HttpGet]
        public ActionResult queries()
        {
            return View();
        }

        [HttpGet]
        public ActionResult headers()
        {
            return View();
        }
    }
}
