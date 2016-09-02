﻿using System;
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
            systemConfigurationModel.saveActiveDirectory(Request.Form["ADDomain"], Request.Form["ADPath"]);

            string json = "{\"message\":\"Configuration Active Directory Success.\"}";
            Response.Clear();
            Response.ContentType = "application/json; charset=utf-8";
            Response.Write(json);
            Response.End();

            // Select and return activeDirectories
            /*
            List<ActiveDirectoryParameter> activeDirectories = systemConfigurationModel.getActiveDirectories();
           
            Response.ContentType = "application/json; charset=utf-8";
            var response = Newtonsoft.Json.JsonConvert.SerializeObject(activeDirectories);
            Response.Write(response);
            Response.End();
            */
        }

        [HttpGet]
        public ActionResult serversmtp()
        {
            return View();
        }

        [HttpPost]
        public void saveServerSmtp()
        {
            Response.ContentType = "application/json; charset=utf-8";
          
            ServerSMTPParameter serverSmtp = new ServerSMTPParameter();

            serverSmtp.NameServerSMTP = Request.Form["NameServerSMTP"];
            serverSmtp.Port = Request.Form["Port"]; 
            serverSmtp.UsernameSMTP = Request.Form["UsernameSMTP"];
            serverSmtp.PasswordSMTP = Request.Form["PasswordSMTP"];
         
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(serverSmtp);
            Response.Write(json);
            Response.End();              
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
