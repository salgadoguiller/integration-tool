using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using IntegrationTool.Models;
using ClassLibrary;

namespace IntegrationTool.Controllers
{
    public class ConfigurationController : Controller
    {
        private SystemConfiguration systemConfigurationModel;
        private Encrypt encryptor;

        private void connectModel()
        {
            systemConfigurationModel = new SystemConfiguration();
            encryptor = new Encrypt();
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
        [HttpPut]
        public void saveActiveDirectory()
        {
            string resp = "";
            try
            {
                connectModel();

                systemConfigurationModel.saveActiveDirectory(encryptor.encryptData(Request.Form["ADDomain"]), encryptor.encryptData(Request.Form["ADPath"]));

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

        [HttpPut]
        public void saveServerSmtp()
        {
            string resp = "";
            try
            {
                connectModel();
                systemConfigurationModel.saveServerSMPT(encryptor.encryptData(Request.Form["NameServerSMTP"]), encryptor.encryptData(Request.Form["Port"]),
                                                        encryptor.encryptData(Request.Form["UsernameSMTP"]), encryptor.encryptData(Request.Form["PasswordSMTP"]));

                resp = "{\"type\":\"success\", \"message\":\"Configuration Server SMTP Successful.\"}";
            }
            catch (Exception)
            {
                resp = "{\"type\":\"danger\", \"message\":\"Configuration Server SMTP Unsuccessful. Please try again.\"}";
            }

            response(resp);
        }

        [HttpPut]
        public void saveDataBase()
        {
            string resp = "";
            try
            {
                connectModel();
                systemConfigurationModel.saveDatabase(encryptor.encryptData(Request.Form["Ip"]), encryptor.encryptData(Request.Form["Instance"]),
                                                    encryptor.encryptData(Request.Form["Name"]), encryptor.encryptData(Request.Form["Username"]),
                                                    encryptor.encryptData(Request.Form["Password"]), Request.Form["EngineId"],
                                                    encryptor.encryptData(Request.Form["Port"]));

                resp = "{\"type\":\"success\", \"message\":\"Configuration DataBase Successful.\"}";
            }
            catch (Exception ex)
            {
                resp = "{\"type\":\"danger\", \"message\":\"" + ex.Message + "\"}";
                // resp = "{\"type\":\"danger\", \"message\":\"Configuration DataBase Unsuccessful. Please try again.\"}";
            }

            response(resp);
        }

        [HttpPut]
        public void saveWebService()
        {
            string resp = "";
            try
            {
                connectModel();
                systemConfigurationModel.saveWebService(encryptor.encryptData(Request.Form["Endpoint"]), encryptor.encryptData(Request.Form["Username"]),
                                                        encryptor.encryptData(Request.Form["Password"]));

                resp = "{\"type\":\"success\", \"message\":\"Configuration Web Service Successful.\"}";
            }
            catch (Exception)
            {
                resp = "{\"type\":\"danger\", \"message\":\"Configuration Web Service Unsuccessful. Please try again.\"}";
            }

            response(resp);
        }

        [HttpPut]
        public void saveFlatFile()
        {
            string resp = "";
            try
            {
                connectModel();
                systemConfigurationModel.saveFlatFiles(encryptor.encryptData(Request.Form["Location"]));

                resp = "{\"type\":\"success\", \"message\":\"Configuration Flat File Successful.\"}";
            }
            catch (Exception)
            {
                resp = "{\"type\":\"danger\", \"message\":\"Configuration Flat File Unsuccessful. Please try again.\"}";
            }

            response(resp);
        }

        [HttpPut]
        public void saveQuery()
        {
            string resp = "";
            try
            {
                connectModel();
                systemConfigurationModel.saveQuery(encryptor.encryptData(Request.Form["Query1"]), encryptor.encryptData(Request.Form["Description"]), Request.Form["IntegrationTypeId"]);

                resp = "{\"type\":\"success\", \"message\":\"Configuration Query Successful.\"}";
            }
            catch (Exception)
            {
                resp = "{\"type\":\"danger\", \"message\":\"Configuration Query Unsuccessful. Please try again.\"}";
            }

            response(resp);
        }

        // ================================================================================================================
        // Actualiza en base de datos parametros del sistema.
        // ================================================================================================================
        [HttpPost]
        public void updateActiveDirectory()
        {
            string resp = "";
            try
            {
                connectModel();
                systemConfigurationModel.updateActiveDirectory(Convert.ToInt32(Request.Form["ActiveDirectoryId"]),
                                                                encryptor.encryptData(Request.Form["ADDomain"]),
                                                                encryptor.encryptData(Request.Form["ADPath"]));

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
        public void updateServerSmtp()
        {
            string resp = "";
            try
            {
                connectModel();
                systemConfigurationModel.updateServerSMPT(Convert.ToInt32(Request.Form["ServerSMTPParametersId"]),
                                                            encryptor.encryptData(Request.Form["NameServerSMTP"]),
                                                            encryptor.encryptData(Request.Form["Port"]),
                                                            encryptor.encryptData(Request.Form["UsernameSMTP"]),
                                                            encryptor.encryptData(Request.Form["PasswordSMTP"]));

                resp = "{\"type\":\"success\", \"message\":\"Configuration Server SMTP Successful.\"}";
            }
            catch (Exception)
            {
                resp = "{\"type\":\"danger\", \"message\":\"Configuration Server SMTP Unsuccessful. Please try again.\"}";
            }

            response(resp);
        }

        [HttpPost]
        public void updateDataBase()
        {
            string resp = "";
            try
            {
                connectModel();
                systemConfigurationModel.updateDatabase(Convert.ToInt32(Request.Form["DatabaseParametersId"]),
                                                        encryptor.encryptData(Request.Form["Ip"]),
                                                        encryptor.encryptData(Request.Form["Instance"]),
                                                        encryptor.encryptData(Request.Form["Name"]),
                                                        encryptor.encryptData(Request.Form["Username"]),
                                                        encryptor.encryptData(Request.Form["Password"]),
                                                        Convert.ToInt32(Request.Form["EngineId"]),
                                                        encryptor.encryptData(Request.Form["Port"]));

                resp = "{\"type\":\"success\", \"message\":\"Configuration DataBase Successful.\"}";
            }
            catch (Exception)
            {
                resp = "{\"type\":\"danger\", \"message\":\"Configuration DataBase Unsuccessful. Please try again.\"}";
            }

            response(resp);
        }

        [HttpPost]
        public void updateWebService()
        {
            string resp = "";
            try
            {
                connectModel();
                systemConfigurationModel.updateWebService(Convert.ToInt32(Request.Form["WebServiceId"]),
                                                        encryptor.encryptData(Request.Form["Endpoint"]),
                                                        encryptor.encryptData(Request.Form["Username"]),
                                                        encryptor.encryptData(Request.Form["Password"]));

                resp = "{\"type\":\"success\", \"message\":\"Configuration Web Service Successful.\"}";
            }
            catch (Exception)
            {
                resp = "{\"type\":\"danger\", \"message\":\"Configuration Web Service Unsuccessful. Please try again.\"}";
            }

            response(resp);
        }

        [HttpPost]
        public void updateFlatFile()
        {
            string resp = "";
            try
            {
                connectModel();
                systemConfigurationModel.updateFlatFile(Convert.ToInt32(Request.Form["FlatFileParameterId"]),
                                                        encryptor.encryptData(Request.Form["Location"]));

                resp = "{\"type\":\"success\", \"message\":\"Configuration Flat File Successful.\"}";
            }
            catch (Exception)
            {
                resp = "{\"type\":\"danger\", \"message\":\"Configuration Flat File Unsuccessful. Please try again.\"}";
            }

            response(resp);
        }

        [HttpPost]
        public void updateQuery()
        {
            string resp = "";
            try
            {
                connectModel();
                systemConfigurationModel.updateQuery(Convert.ToInt32(Request.Form["QueryId"]),
                                                    encryptor.encryptData(Request.Form["Query1"]),
                                                    encryptor.encryptData(Request.Form["Description"]),
                                                    Convert.ToInt32(Request.Form["IntegrationTypeId"]));

                resp = "{\"type\":\"success\", \"message\":\"Configuration Query Successful.\"}";
            }
            catch (Exception)
            {
                resp = "{\"type\":\"danger\", \"message\":\"Configuration Query Unsuccessful. Please try again.\"}";
            }

            response(resp);
        }

        // ================================================================================================================
        // Obtiene y retorna parametros del sistema.
        // ================================================================================================================
        [HttpGet]
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

        [HttpGet]
        public void getIntegrationsType()
        {
            string resp = "";
            try
            {
                connectModel();
                List<IntegrationsType> integrationsType = systemConfigurationModel.getIntegrationsType();

                resp = Newtonsoft.Json.JsonConvert.SerializeObject(integrationsType,
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

        [HttpGet]
        public void getlistQueries()
        {
            string resp = "";
            try
            {
                connectModel();
                List<Query> queries = systemConfigurationModel.getQueries();

                foreach (Query query in queries)
                {
                    query.Query1 = encryptor.decryptData(query.Query1);
                    query.Description = encryptor.decryptData(query.Description);
                }

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

        [HttpGet]
        public void getlistActiveDirectories()
        {
            string resp = "";
            try
            {
                connectModel();
                List<ActiveDirectoryParameter> activeDirectories = systemConfigurationModel.getActiveDirectories();

                foreach (ActiveDirectoryParameter activeDirectory in activeDirectories)
                {
                    activeDirectory.ADDomain = encryptor.decryptData(activeDirectory.ADDomain);
                    activeDirectory.ADPath = encryptor.decryptData(activeDirectory.ADPath);
                }

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

        [HttpGet]
        public void getListFlatFiles()
        {
            string resp = "";
            try
            {
                connectModel();
                List<FlatFilesParameter> flatFiles = systemConfigurationModel.getFlatFiles();

                foreach (FlatFilesParameter flatFile in flatFiles)
                {
                    flatFile.Location = encryptor.decryptData(flatFile.Location);
                }

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

        [HttpGet]
        public void getListServersSMTP()
        {
            string resp = "";
            try
            {
                connectModel();
                List<ServerSMTPParameter> serverSMTP = systemConfigurationModel.getServersSMTP();

                foreach (ServerSMTPParameter server in serverSMTP)
                {
                    server.NameServerSMTP = encryptor.decryptData(server.NameServerSMTP);
                    server.Port = encryptor.decryptData(server.Port);
                    server.UsernameSMTP = encryptor.decryptData(server.UsernameSMTP);
                    server.PasswordSMTP = encryptor.decryptData(server.PasswordSMTP);
                }

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

        [HttpGet]
        public void getListDatabases()
        {
            string resp = "";
            
            //try
            //{
                connectModel();
                List<DatabaseParameter> databases = systemConfigurationModel.getDatabases();

                foreach (DatabaseParameter database in databases)
                {
                    database.Ip = encryptor.decryptData(database.Ip);
                    database.Port = encryptor.decryptData(database.Port);
                    database.Instance = encryptor.decryptData(database.Instance);
                    database.Name = encryptor.decryptData(database.Name);
                    database.Username = encryptor.decryptData(database.Username);
                    database.Password = encryptor.decryptData(database.Password);
                }

                resp = Newtonsoft.Json.JsonConvert.SerializeObject(databases,
                    new JsonSerializerSettings()
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                    });
            /*}
            catch (Exception ex)
            {
                resp = "{\"type\":\"danger\", \"message\":\"" + ex.Message + "\"}";
                // resp = "{\"type\":\"danger\", \"message\":\"Can not be loaded the databases. Please try again.\"}";
            }*/

            response(resp);
        }

        [HttpGet]
        public void getListWebServices()
        {
            string resp = "";
            try
            {
                connectModel();
                List<WebService> webServices = systemConfigurationModel.getWebServices();

                foreach (WebService webService in webServices)
                {
                    webService.Endpoint = encryptor.decryptData(webService.Endpoint);
                    webService.Username = encryptor.decryptData(webService.Username);
                    webService.Password = encryptor.decryptData(webService.Password);
                }

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

        [HttpGet]
        public void getActiveDirectory(int id)
        {
            string resp = "";
            try
            {
                connectModel();
                ActiveDirectoryParameter activeDirectory = systemConfigurationModel.getActiveDirectory(id);

                activeDirectory.ADDomain = encryptor.decryptData(activeDirectory.ADDomain);
                activeDirectory.ADPath = encryptor.decryptData(activeDirectory.ADPath);

                resp = Newtonsoft.Json.JsonConvert.SerializeObject(activeDirectory,
                    new JsonSerializerSettings()
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                    });
            }
            catch (Exception)
            {
                resp = "{\"type\":\"danger\", \"message\":\"Can not be loaded the active directory. Please try again.\"}";
            }

            response(resp);
        }

        [HttpGet]
        public void getDatabase(int id)
        {
            string resp = "";
            try
            {
                connectModel();
                DatabaseParameter database = systemConfigurationModel.getDatabase(id);

                database.Ip = encryptor.decryptData(database.Ip);
                database.Port = encryptor.decryptData(database.Port);
                database.Instance = encryptor.decryptData(database.Instance);
                database.Name = encryptor.decryptData(database.Name);
                database.Username = encryptor.decryptData(database.Username);
                database.Password = encryptor.decryptData(database.Password);

                resp = Newtonsoft.Json.JsonConvert.SerializeObject(database,
                    new JsonSerializerSettings()
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                    });
            }
            catch (Exception)
            {
                resp = "{\"type\":\"danger\", \"message\":\"Can not be loaded the database. Please try again.\"}";
            }

            response(resp);
        }

        [HttpGet]
        public void getFlatFile(int id)
        {
            string resp = "";
            try
            {
                connectModel();
                FlatFilesParameter flatFile = systemConfigurationModel.getFlatFile(id);

                flatFile.Location = encryptor.decryptData(flatFile.Location);

                resp = Newtonsoft.Json.JsonConvert.SerializeObject(flatFile,
                    new JsonSerializerSettings()
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                    });
            }
            catch (Exception)
            {
                resp = "{\"type\":\"danger\", \"message\":\"Can not be loaded the flat file. Please try again.\"}";
            }

            response(resp);
        }

        [HttpGet]
        public void getQuery(int id)
        {
            string resp = "";
            try
            {
                connectModel();
                Query query = systemConfigurationModel.getQuery(id);

                query.Query1 = encryptor.decryptData(query.Query1);
                query.Description = encryptor.decryptData(query.Description);

                resp = Newtonsoft.Json.JsonConvert.SerializeObject(query,
                    new JsonSerializerSettings()
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                    });
            }
            catch (Exception)
            {
                resp = "{\"type\":\"danger\", \"message\":\"Can not be loaded the query. Please try again.\"}";
            }

            response(resp);
        }

        [HttpGet]
        public void getServerSMTP(int id)
        {
            string resp = "";
            try
            {
                connectModel();
                ServerSMTPParameter serverSMTP = systemConfigurationModel.getServerSMTP(id);

                serverSMTP.NameServerSMTP = encryptor.decryptData(serverSMTP.NameServerSMTP);
                serverSMTP.Port = encryptor.decryptData(serverSMTP.Port);
                serverSMTP.UsernameSMTP = encryptor.decryptData(serverSMTP.UsernameSMTP);
                serverSMTP.PasswordSMTP = encryptor.decryptData(serverSMTP.PasswordSMTP);

                resp = Newtonsoft.Json.JsonConvert.SerializeObject(serverSMTP,
                    new JsonSerializerSettings()
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                    });
            }
            catch (Exception)
            {
                resp = "{\"type\":\"danger\", \"message\":\"Can not be loaded the server SMTP. Please try again.\"}";
            }

            response(resp);
        }

        [HttpGet]
        public void getWebService(int id)
        {
            string resp = "";
            try
            {
                connectModel();
                WebService webService = systemConfigurationModel.getWebService(id);

                webService.Endpoint = encryptor.decryptData(webService.Endpoint);
                webService.Username = encryptor.decryptData(webService.Username);
                webService.Password = encryptor.decryptData(webService.Password);

                resp = Newtonsoft.Json.JsonConvert.SerializeObject(webService,
                    new JsonSerializerSettings()
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                    });
            }
            catch (Exception)
            {
                resp = "{\"type\":\"danger\", \"message\":\"Can not be loaded the web service. Please try again.\"}";
            }

            response(resp);
        }

        // ================================================================================================================
        // Eliminar parametros del sistema
        // ================================================================================================================
        [HttpDelete]
        public void deleteActiveDirectory(int id)
        {
            string resp = "";
            try
            {
                connectModel();
                systemConfigurationModel.deleteActiveDirectory(id);

                resp = "{\"type\":\"success\", \"message\":\"Active directory deleted Successfully.\"}";

            }
            catch (Exception ex)
            {
                resp = "{\"type\":\"danger\", \"message\":\"" + ex.Message + "\"}";
                // resp = "{\"type\":\"danger\", \"message\":\"Can not be deleted the active directory. Please try again.\"}";
            }

            response(resp);
        }

        [HttpDelete]
        public void deleteDataBase(int id)
        {
            string resp = "";
            try
            {
                connectModel();
                systemConfigurationModel.deleteDataBase(id);

                resp = "{\"type\":\"success\", \"message\":\"Database deleted Successfully.\"}";

            }
            catch (Exception )
            {
                resp = "{\"type\":\"danger\", \"message\":\"Can not be deleted the database. Please try again.\"}";
            }

            response(resp);
        }

        [HttpDelete]
        public void deleteFlatFile(int id)
        {
            string resp = "";
            try
            {
                connectModel();
                systemConfigurationModel.deleteFlatFile(id);

                resp = "{\"type\":\"success\", \"message\":\"Flat file deleted Successfully.\"}";

            }
            catch (Exception)
            {
                resp = "{\"type\":\"danger\", \"message\":\"Can not be deleted the flat file. Please try again.\"}";
            }

            response(resp);
        }

        [HttpDelete]
        public void deleteQuery(int id)
        {
            string resp = "";
            try
            {
                connectModel();
                systemConfigurationModel.deleteQuery(id);

                resp = "{\"type\":\"success\", \"message\":\"Query deleted Successfully.\"}";

            }
            catch (Exception)
            {
                resp = "{\"type\":\"danger\", \"message\":\"Can not be deleted the query. Please try again.\"}";
            }

            response(resp);
        }

        [HttpDelete]
        public void deleteServerSMTP(int id)
        {
            string resp = "";
            try
            {
                connectModel();
                systemConfigurationModel.deleteServerSMTP(id);

                resp = "{\"type\":\"success\", \"message\":\"Server SMTP deleted Successfully.\"}";

            }
            catch (Exception)
            {
                resp = "{\"type\":\"danger\", \"message\":\"Can not be deleted the server SMTP. Please try again.\"}";
            }

            response(resp);
        }

        [HttpDelete]
        public void deleteWebService(int id)
        {
            string resp = "";
            try
            {
                connectModel();
                systemConfigurationModel.deleteWebService(id);

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
