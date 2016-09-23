using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using IntegrationTool.Models;
using System.Security.Principal;
using System.Threading;
using Newtonsoft.Json;

namespace IntegrationTool.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        [AllowAnonymous]
        [HttpGet]
        public ActionResult viewLogin()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public void login()
        {
            AccountModel accountModel = new AccountModel();

            string resp = "";
            if (Membership.ValidateUser(Request.Form["Username"], Request.Form["Password"]))
            {
                try
                {
                    User user = accountModel.getUser(Request.Form["Username"]);
                    FormsAuthentication.SetAuthCookie(Request.Form["Username"], true);
                    resp = serializeObject(user);
                }
                catch (ArgumentOutOfRangeException)
                {
                    resp = "{\"type\":\"danger\", \"message\":\"User don´t have permissions.\"}";
                }
            }
            else
            {
                if (accountModel.validateLocalUser(Request.Form["Username"], Request.Form["Password"]))
                {
                    User user = accountModel.getUser(Request.Form["Username"]);
                    FormsAuthentication.SetAuthCookie(Request.Form["Username"], true);
                    resp = serializeObject(user);
                }
                else
                {
                    resp = "{\"type\":\"danger\", \"message\":\"User or password incorrect. Please try again.\"}";
                }
            }

            response(resp);
        }

        [HttpPost]
        public void Logout()
        {
            FormsAuthentication.SignOut();

            string resp = "{\"type\":\"danger\", \"message\":\"Logout succesfully.\"}";

            response(resp);
        }

        [HttpGet]
        public static bool isAuthenticated()
        {
            IPrincipal user = Thread.CurrentPrincipal;

            if (user.Identity.IsAuthenticated)
                return true;
            else
                return false;
        }

        // ================================================================================================================
        // Metodos privados que proveen funcionalidad a las acciones del controlador.
        // ================================================================================================================
        private void response(string json)
        {
            Response.Clear();
            Response.ContentType = "application/json; charset=utf-8";
            Response.Write(json);
            Response.End();
        }

        private string serializeObject(Object obj)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(obj,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
        }
    }
}
