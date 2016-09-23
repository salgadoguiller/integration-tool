using IntegrationTool.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClassLibrary;

namespace IntegrationTool.Controllers
{
    public class ReportController : Controller
    {
        private ReportsConfiguration ReportsConfigurationModel;
        private Encrypt encryptor = new Encrypt();

        private void connectModel()
        {
            ReportsConfigurationModel = new ReportsConfiguration();

        }

        private void response(string json)
        {
            Response.Clear();
            Response.ContentType = "application/json; charset=utf-8";
            Response.Write(json);
            Response.End();
        }

        [HttpGet]
        public ActionResult getReport()
        {        
            return View();
        }

        [HttpGet]
        public void getListCategoryIntegration()
        {
            string resp = "";
            try
            {
                connectModel();

                List<IntegrationCategory> integrationCategory = ReportsConfigurationModel.getCategoryIntegration();

                resp = Newtonsoft.Json.JsonConvert.SerializeObject(integrationCategory,
                    new JsonSerializerSettings()
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                    });
            }
            catch (Exception)
            {
                resp = "{\"type\":\"danger\", \"message\":\"Can not be loaded the Integration Category. Please try again.\"}";
            }

            response(resp);
        }

        [HttpGet]
        public void getListIntegrationType()
        {
            string resp = "";
            try
            {
                connectModel();

                List<IntegrationsType> integrationType = ReportsConfigurationModel.getIntegrationType();

                resp = Newtonsoft.Json.JsonConvert.SerializeObject(integrationType,
                    new JsonSerializerSettings()
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                    });
            }
            catch (Exception)
            {
                resp = "{\"type\":\"danger\", \"message\":\"Can not be loaded the Integration Category. Please try again.\"}";
            }

            response(resp);
        }

        [HttpGet]
        public void getListOperationWebServices()
        {
            string resp = "";
            try
            {
                connectModel();

                List<OperationsWebService> operationWebServices = ReportsConfigurationModel.getOperationWebServices();

                resp = Newtonsoft.Json.JsonConvert.SerializeObject(operationWebServices,
                    new JsonSerializerSettings()
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                    });
            }
            catch (Exception)
            {
                resp = "{\"type\":\"danger\", \"message\":\"Can not be loaded the Integration Category. Please try again.\"}";
            }

            response(resp);
        }

        [HttpGet]
        public void getListDatabaseParameter()
        {
            string resp = "";
            try
            {
                connectModel();

                List<DatabaseParameter> databaseParameter = ReportsConfigurationModel.getDatabaseParameter();

                foreach (DatabaseParameter database in databaseParameter)
                {
                    database.Name =  encryptor.decryptData(database.Name);                 
                }

                resp = serializeObject(databaseParameter);            
            }
            catch (Exception)
            {
                resp = "{\"type\":\"danger\", \"message\":\"Can not be loaded the Integration Category. Please try again.\"}";
            }

            response(resp);
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
