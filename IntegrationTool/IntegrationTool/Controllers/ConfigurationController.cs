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

        // ================================================================================================================
        // Retornan formularios para insertar o actualizar parametros del sistema.
        // ================================================================================================================
        [HttpGet]
        public ActionResult formActiveDirectory()
        {
            return View();
        }

        [HttpGet]
        public ActionResult formServerSMTP()
        {
            return View();
        }

        [HttpGet]
        public ActionResult formDatabase()
        {
            return View();
        }

        [HttpGet]
        public ActionResult formWebService()
        {
            return View();
        }

        [HttpGet]
        public ActionResult formFlatFile()
        {
            return View();
        }

        [HttpGet]
        public ActionResult formQuery()
        {
            return View();
        }

        [HttpGet]
        public ActionResult formHeaders()
        {
            return View();
        }

        // ================================================================================================================
        // Lista parametros del sistema.
        // ================================================================================================================
        [HttpGet]
        public ActionResult listActiveDirectories()
        {
            return View();
        }

        [HttpGet]
        public ActionResult listDatabases()
        {
            return View();
        }

        [HttpGet]
        public ActionResult listFlatFiles()
        {
            return View();
        }

        [HttpGet]
        public ActionResult listHeaders()
        {
            return View();
        }

        [HttpGet]
        public ActionResult listQueries()
        {
            return View();
        }

        [HttpGet]
        public ActionResult listServerSMTP()
        {
            return View();
        }

        [HttpGet]
        public ActionResult listWebServices()
        {
            return View();
        }

        // ================================================================================================================
        // Almacena en base de datos parametros del sistema.
        // ================================================================================================================
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

        [HttpPost]
        public void saveFlatFile()
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

        [HttpPost]
        public void saveQuery()
        {
            string resp = "";
            try
            {
                connectModel();
                systemConfigurationModel.saveQuery(Request.Form["Queries"], Request.Form["typeQueries"]);

                resp = "{\"type\":\"success\", \"message\":\"Configuration Query Successful.\"}";
            }
            catch (Exception)
            {
                resp = "{\"type\":\"danger\", \"message\":\"Configuration Query Unsuccessful. Please try again.\"}";
            }

            response(resp);
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

        // ================================================================================================================
        // Obtiene y retorna parametros del sistema.
        // ================================================================================================================
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
                List<QueriesType> typeQueries = systemConfigurationModel.getTypeQueries();

                resp = Newtonsoft.Json.JsonConvert.SerializeObject(typeQueries,
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

        public void getlistQueries()
        {
            string resp = "";
            try
            {
                connectModel();
                List<Query> queries = systemConfigurationModel.getQueries();

                resp = Newtonsoft.Json.JsonConvert.SerializeObject(queries,
                    new JsonSerializerSettings()
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                    });
            }
            catch (Exception)
            {
                resp = "{\"type\":\"danger\", \"message\":\"Can not be loaded the queries. Please try again.\"}";
            }

            response(resp);
        }

        public void getlistActiveDirectories()
        {
            string resp = "";
            try
            {
                connectModel();
                List<ActiveDirectoryParameter> activeDirectories = systemConfigurationModel.getActiveDirectories();

                resp = Newtonsoft.Json.JsonConvert.SerializeObject(activeDirectories,
                    new JsonSerializerSettings()
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                    });
            }
            catch (Exception)
            {
                resp = "{\"type\":\"danger\", \"message\":\"Can not be loaded the active directories. Please try again.\"}";
            }

            response(resp);
        }

        public void getListFlatFiles()
        {
            string resp = "";
            try
            {
                connectModel();
                List<FlatFileParameter> flatFiles = systemConfigurationModel.getFlatFiles();

                resp = Newtonsoft.Json.JsonConvert.SerializeObject(flatFiles,
                    new JsonSerializerSettings()
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                    });
            }
            catch (Exception)
            {
                resp = "{\"type\":\"danger\", \"message\":\"Can not be loaded the flat files. Please try again.\"}";
            }

            response(resp);
        }

        public void getListServersSMTP()
        {
            string resp = "";
            try
            {
                connectModel();
                List<ServerSMTPParameter> serverSMTP = systemConfigurationModel.getServersSMTP();

                resp = Newtonsoft.Json.JsonConvert.SerializeObject(serverSMTP,
                    new JsonSerializerSettings()
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                    });
            }
            catch (Exception)
            {
                resp = "{\"type\":\"danger\", \"message\":\"Can not be loaded the servers SMTP. Please try again.\"}";
            }

            response(resp);
        }

        public void getListDatabases()
        {
            string resp = "";
            try
            {
                connectModel();
                List<DatabaseParameter> databases = systemConfigurationModel.getDatabases();

                resp = Newtonsoft.Json.JsonConvert.SerializeObject(databases,
                    new JsonSerializerSettings()
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                    });
            }
            catch (Exception)
            {
                resp = "{\"type\":\"danger\", \"message\":\"Can not be loaded the databases. Please try again.\"}";
            }

            response(resp);
        }

        public void getListHeaders()
        {
            string resp = "";
            try
            {
                connectModel();
                List<Header> headers = systemConfigurationModel.getHeaders();

                resp = Newtonsoft.Json.JsonConvert.SerializeObject(headers,
                    new JsonSerializerSettings()
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                    });
            }
            catch (Exception)
            {
                resp = "{\"type\":\"danger\", \"message\":\"Can not be loaded the headers. Please try again.\"}";
            }

            response(resp);
        }

        public void getListWebServices()
        {
            string resp = "";
            try
            {
                connectModel();
                List<WebService> webServices = systemConfigurationModel.getWebServices();

                resp = Newtonsoft.Json.JsonConvert.SerializeObject(webServices,
                    new JsonSerializerSettings()
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                    });
            }
            catch (Exception)
            {
                resp = "{\"type\":\"danger\", \"message\":\"Can not be loaded the web services. Please try again.\"}";
            }

            response(resp);
        }

        // ================================================================================================================
        // Eliminar parametros del sistema
        // ================================================================================================================
        [HttpPost]
        public void deleteActiveDirectory()
        {
            string resp = "";
            try
            {
                connectModel();
                systemConfigurationModel.deleteActiveDirectory(Convert.ToInt32(Request.Form["ActiveDirectoryId"]));

                resp = "{\"type\":\"success\", \"message\":\"Active directory deleted Successfully.\"}";

            }
            catch (Exception)
            {
                resp = "{\"type\":\"danger\", \"message\":\"Can not be deleted the active directory. Please try again.\"}";
            }

            response(resp);
        }

        [HttpPost]
        public void deleteDataBase()
        {
            string resp = "";
            try
            {
                connectModel();
                systemConfigurationModel.deleteDataBase(Convert.ToInt32(Request.Form["DatabaseParametersId"]));

                resp = "{\"type\":\"success\", \"message\":\"Database deleted Successfully.\"}";

            }
            catch (Exception )
            {
                resp = "{\"type\":\"danger\", \"message\":\"Can not be deleted the database. Please try again.\"}";
            }

            response(resp);
        }

        [HttpPost]
        public void deleteFlatFile()
        {
            string resp = "";
            try
            {
                connectModel();
                systemConfigurationModel.deleteFlatFile(Convert.ToInt32(Request.Form["FlatFileParametersId"]));

                resp = "{\"type\":\"success\", \"message\":\"Flat file deleted Successfully.\"}";

            }
            catch (Exception)
            {
                resp = "{\"type\":\"danger\", \"message\":\"Can not be deleted the flat file. Please try again.\"}";
            }

            response(resp);
        }

        [HttpPost]
        public void deleteHeader()
        {
            string resp = "";
            try
            {
                connectModel();
                systemConfigurationModel.deleteHeader(Convert.ToInt32(Request.Form["HeaderId"]));

                resp = "{\"type\":\"success\", \"message\":\"Header deleted Successfully.\"}";

            }
            catch (Exception)
            {
                resp = "{\"type\":\"danger\", \"message\":\"Can not be deleted the header. Please try again.\"}";
            }

            response(resp);
        }

        [HttpPost]
        public void deleteQuery()
        {
            string resp = "";
            try
            {
                connectModel();
                systemConfigurationModel.deleteQuery(Convert.ToInt32(Request.Form["QueryId"]));

                resp = "{\"type\":\"success\", \"message\":\"Query deleted Successfully.\"}";

            }
            catch (Exception)
            {
                resp = "{\"type\":\"danger\", \"message\":\"Can not be deleted the query. Please try again.\"}";
            }

            response(resp);
        }

        [HttpPost]
        public void deleteServerSMTP()
        {
            string resp = "";
            try
            {
                connectModel();
                systemConfigurationModel.deleteServerSMTP(Convert.ToInt32(Request.Form["ServerSMTPParametersId"]));

                resp = "{\"type\":\"success\", \"message\":\"Server SMTP deleted Successfully.\"}";

            }
            catch (Exception)
            {
                resp = "{\"type\":\"danger\", \"message\":\"Can not be deleted the server SMTP. Please try again.\"}";
            }

            response(resp);
        }

        [HttpPost]
        public void deleteWebService()
        {
            string resp = "";
            try
            {
                connectModel();
                systemConfigurationModel.deleteWebService(Convert.ToInt32(Request.Form["WebServiceId"]));

                resp = "{\"type\":\"success\", \"message\":\"Web service deleted Successfully.\"}";

            }
            catch (Exception)
            {
                resp = "{\"type\":\"danger\", \"message\":\"Can not be deleted the web service. Please try again.\"}";
            }

            response(resp);
        }
    }
}
