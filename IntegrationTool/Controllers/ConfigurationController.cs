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

        private void response(string json)
        {
            Response.Clear();
            Response.ContentType = "application/json; charset=utf-8";
            Response.Write(json);
            Response.End();
        }

        [HttpGet]
        public ActionResult activedirectorymain()
        {
            return View();
        }

        [HttpGet]
        public ActionResult activedirectory()
        {
            return View();
        }

        [HttpPost]
        public void saveActiveDirectory()
        {
            string resp = "";
            try
            {
                connectModel();
                systemConfigurationModel.saveActiveDirectory(Request.Form["ADDomain"], Request.Form["ADPath"]);

                resp = "{\"type\":\"success\", \"message\":\"Configuration Active Directory Successful.\"}";
            }
            catch (Exception)
            {
                resp = "{\"type\":\"danger\", \"message\":\"Configuration Active Directory Unsuccessful. Please try again.\"}";
            }
            

            response(resp);

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
            string resp = "";
            try
            {
                connectModel();
                systemConfigurationModel.saveServerSMPT(Request.Form["NameServerSMTP"], Request.Form["Port"], Request.Form["UsernameSMTP"], Request.Form["PasswordSMTP"]);

                resp = "{\"type\":\"success\", \"message\":\"Configuration Server SMTP Successful.\"}";
            }
            catch (Exception)
            {
                resp = "{\"type\":\"danger\", \"message\":\"Configuration Server SMTP Unsuccessful. Please try again.\"}";
            }

            response(resp);
        }

        [HttpGet]
        public ActionResult databases()
        {
            return View();
        }

        [HttpPost]
        public void saveDataBase()
        {
            string resp = "";
            try
            {
                connectModel();
                systemConfigurationModel.saveDatabase(Request.Form["Ip"], Request.Form["Instance"], Request.Form["Name"], Request.Form["Username"], Request.Form["Password"], Request.Form["EngineId"], Request.Form["Port"]);

                resp = "{\"type\":\"success\", \"message\":\"Configuration DataBase Successful.\"}";
            }
            catch (Exception)
            {
                resp = "{\"type\":\"danger\", \"message\":\"Configuration DataBase Unsuccessful. Please try again.\"}";
            }

            response(resp);
        }

        [HttpGet]
        public ActionResult webservices()
        {
            return View();
        }

        [HttpPost]
        public void saveWebService()
        {
            string resp = "";
            try
            {
                connectModel();
                systemConfigurationModel.saveWebService(Request.Form["Endpoint"], Request.Form["Username"], Request.Form["Password"]);

                resp = "{\"type\":\"success\", \"message\":\"Configuration Web Service Successful.\"}";
            }
            catch (Exception)
            {
                resp = "{\"type\":\"danger\", \"message\":\"Configuration Web Service Unsuccessful. Please try again.\"}";
            }

            response(resp);
        }

        [HttpGet]
        public ActionResult flatfiles()
        {
            return View();
        }

        [HttpPost]
        public void saveFlatFiles()
        {
            string resp = "";
            try
            {
                connectModel();
                systemConfigurationModel.saveFlatFiles(Request.Form["Location"]);

                resp = "{\"type\":\"success\", \"message\":\"Configuration Flat File Successful.\"}";
            }
            catch (Exception)
            {
                resp = "{\"type\":\"danger\", \"message\":\"Configuration Flat File Unsuccessful. Please try again.\"}";
            }

            response(resp);
        }

        [HttpGet]
        public ActionResult queries()
        {
            return View();
        }

        [HttpPost]
        public void saveQueries()
        {
            string resp = "";
            try
            {
                connectModel();
                systemConfigurationModel.saveQueries(Request.Form["Queries"], Request.Form["typeQueries"]);

                resp = "{\"type\":\"success\", \"message\":\"Configuration Query Successful.\"}";
            }
            catch (Exception)
            {
                resp = "{\"type\":\"danger\", \"message\":\"Configuration Query Unsuccessful. Please try again.\"}";
            }

            response(resp);
        }

        [HttpGet]
        public ActionResult headers()
        {
            return View();
        }

        [HttpPost]
        public void saveHeaders()
        {
            string resp = "";
            try
            {
                connectModel();
                systemConfigurationModel.saveHeaders(Request.Form["QueryTypeId"], Request.Form["Name"]);

                resp = "{\"type\":\"success\", \"message\":\"Configuration Headers Successful.\"}";
            }
            catch (Exception)
            {
                resp = "{\"type\":\"danger\", \"message\":\"Configuration Headers Unsuccessful. Please try again.\"}";
            }

            response(resp);
        }

        [HttpPost]
        public void getDataBaseEngines()
        {
            string resp = "";
            try
            {
                connectModel();
                List<Engine> engines = systemConfigurationModel.getDataBaseEngines();

                resp = Newtonsoft.Json.JsonConvert.SerializeObject(engines,
                    new JsonSerializerSettings()
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                    });
            }
            catch (Exception)
            {
                resp = "{\"type\":\"danger\", \"message\":\"Can not be loaded the engines. Please try again.\"}";
            }

            response(resp);
        }

        public void getTypeQueries()
        {
            string resp = "";
            try
            {
                connectModel();
                List<QueriesType> queriesTypes = systemConfigurationModel.getTypeQueries();

                resp = Newtonsoft.Json.JsonConvert.SerializeObject(queriesTypes,
                    new JsonSerializerSettings()
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                    });
            }
            catch (Exception)
            {
                resp = "{\"type\":\"danger\", \"message\":\"Can not be loaded the type queries. Please try again.\"}";
            }

            response(resp);
        }
    }
}
