using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IntegrationTool.Controllers
{
    [Authorize]
    public class MainController : Controller
    {
        [AllowAnonymous]
        [HttpGet]
        public ActionResult index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult layout()
        {
            return View();
        }
    }
}
