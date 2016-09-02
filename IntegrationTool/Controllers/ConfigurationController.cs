using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using IntegrationTool.Models;

namespace IntegrationTool.Controllers
{
    public class ConfigurationController : Controller
    {
        private SystemConfiguration systemConfigurationModel;

        private void connectModel()
        {
            systemConfigurationModel = new SystemConfiguration();
        }

        [HttpGet]
        public ActionResult activedirectory()
        {
            return View();
        }

        [HttpPost]
        public void saveActiveDirectory()
        {
            connectModel();
            systemConfigurationModel.getActiveDirectories();
            
            /*
            string json = "{\"message\":\"Configuration Active Directory Success.\"}";
            Response.Clear();
            Response.ContentType = "application/json; charset=utf-8";
            Response.Write(json);
            Response.End(); 
            */

            /*
            Response.ContentType = "application/json; charset=utf-8";
            ActiveDirectoryParameter ad = new ActiveDirectoryParameter();
            ad.ADDomain = Request.Form["ADDomain"];
            ad.ADPath = Request.Form["ADPath"];
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(ad);
            Response.Write(json);
            Response.End();
            */

            /*
            string json = "{\"name\":\"Joe\"}";
            Response.Clear();
            Response.ContentType = "application/json; charset=utf-8";
            Response.Write(json);
            Response.End(); 
            */
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
