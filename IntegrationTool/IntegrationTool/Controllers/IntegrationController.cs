using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Globalization;
using Newtonsoft.Json;
using IntegrationTool.Models;
using ClassLibrary;
using System.Text.RegularExpressions;

namespace IntegrationTool.Controllers
{
    public class IntegrationController : Controller
    {
        private IntegrationConfiguration integrationConfigurationModel;
        private Encrypt encryptor;

        private void connectModel()
        {
            integrationConfigurationModel = new IntegrationConfiguration();
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
        // Retorna las vitas del sistema.
        // ================================================================================================================
        [HttpGet]
        public ActionResult configuration()
        {
            return View();
        }

        [HttpGet]
        public ActionResult calendar()
        {
            return View();
        }

        // ================================================================================================================
        // Almacena en base de datos integraciones automaticas y manuales.
        // ================================================================================================================
        [HttpPut]
        public void saveIntegration()
        {
            string resp = "";
            try
            {
                List<QueryParameter> queryParameters = new List<QueryParameter>();
                Regex regex = new Regex(@"\[\[.*\]\]");

                for (int index = 0; index < Request.Form.Count; index++)
                {
                    Match match = regex.Match(Request.Form.AllKeys[index]);
                    if(match.Success)
                    {
                        QueryParameter qp = new QueryParameter();
                        qp.Name = Request.Form.AllKeys[index];
                        qp.Value = Request.Form[qp.Name];

                        queryParameters.Add(qp);
                    }
                }

                connectModel();

                if (Request.Form["IntegrationCategoryId"] == "1")
                {
                    integrationConfigurationModel.saveIntegrationManual(/*Convert.ToInt32(Request.Form["UserId"])*/ 1,
                                                                Request.Form["CurlParameters"],
                                                                Convert.ToInt32(Request.Form["WebServiceId"]),
                                                                Convert.ToInt32(Request.Form["DatabaseParametersId"]),
                                                                /*Convert.ToInt32(Request.Form["FlatFileId"])*/ 1,
                                                                Convert.ToInt32(Request.Form["FlatFileParameterId"]),
                                                                Convert.ToInt32(Request.Form["IntegrationTypeId"]),
                                                                Convert.ToInt32(Request.Form["QueryId"]),
                                                                Convert.ToInt32(Request.Form["IntegrationCategoryId"]),
                                                                Convert.ToInt32(Request.Form["OperationWebServiceId"]),
                                                                queryParameters);

                    // Execute Integration
                }
                else
                {
                    string format = "ddd MMM dd yyyy HH:mm:ss 'GMT'K '(Central America Standard Time)'";

                    DateTime executionStartDate = DateTime.ParseExact(Request.Form["ExecutionStartDate"], format, CultureInfo.CurrentCulture);
                    DateTime executionEndDate = DateTime.ParseExact(Request.Form["ExecutionEndDate"], format, CultureInfo.CurrentCulture);

                    integrationConfigurationModel.saveIntegrationSchedule(/*Convert.ToInt32(Request.Form["UserId"])*/ 1,
                                                                Request.Form["CurlParameters"],
                                                                Convert.ToInt32(Request.Form["WebServiceId"]),
                                                                Convert.ToInt32(Request.Form["DatabaseParametersId"]),
                                                                /*Convert.ToInt32(Request.Form["FlatFileId"])*/ 1,
                                                                Convert.ToInt32(Request.Form["FlatFileParameterId"]),
                                                                Convert.ToInt32(Request.Form["IntegrationTypeId"]),
                                                                Convert.ToInt32(Request.Form["QueryId"]),
                                                                Convert.ToInt32(Request.Form["IntegrationCategoryId"]),
                                                                Convert.ToInt32(Request.Form["OperationWebServiceId"]),
                                                                queryParameters,
                                                                executionStartDate,
                                                                executionEndDate,
                                                                Request.Form["Emails"],
                                                                Convert.ToInt32(Request.Form["RecurrenceId"]));
                }

                resp = "{\"type\":\"success\", \"message\":\"Integration Successful Stored.\"}";
            }
            catch (Exception ex)
            {
                // resp = "{\"type\":\"danger\", \"message\":\"" + ex.Message + "\"}";
                resp = "{\"type\":\"danger\", \"message\":\"Configuration Active Directory Unsuccessful. Please try again.\"}";
            }


            response(resp);
        }

        // ================================================================================================================
        // Obtiene y retorna datos necesarios para realizar una integración.
        // ================================================================================================================
        [HttpGet]
        public void getQueriesByIntegrationType(int id)
        {
            string resp = "";
            try
            {
                connectModel();
                List<Query> queries = integrationConfigurationModel.getQueriesByIntegrationType(id);

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
        public void getOperationsWebServices()
        {
            string resp = "";
            try
            {
                connectModel();
                List<OperationsWebService> operations = integrationConfigurationModel.getOperationsWebServices();

                resp = Newtonsoft.Json.JsonConvert.SerializeObject(operations,
                    new JsonSerializerSettings()
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                    });
            }
            catch (Exception)
            {
                resp = "{\"type\":\"danger\", \"message\":\"Can not be loaded the operations web services. Please try again.\"}";
            }

            response(resp);
        }

        [HttpGet]
        public void getIntegrationCategories()
        {
            string resp = "";
            try
            {
                connectModel();
                List<IntegrationCategory> integrationCategories = integrationConfigurationModel.getIntegrationCategories();

                resp = Newtonsoft.Json.JsonConvert.SerializeObject(integrationCategories,
                    new JsonSerializerSettings()
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                    });
            }
            catch (Exception)
            {
                resp = "{\"type\":\"danger\", \"message\":\"Can not be loaded the integration categories. Please try again.\"}";
            }

            response(resp);
        }

        [HttpGet]
        public void getRecurrences()
        {
            string resp = "";
            try
            {
                connectModel();
                List<Recurrence> recurrences = integrationConfigurationModel.getRecurrences();

                resp = Newtonsoft.Json.JsonConvert.SerializeObject(recurrences,
                    new JsonSerializerSettings()
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                    });
            }
            catch (Exception)
            {
                resp = "{\"type\":\"danger\", \"message\":\"Can not be loaded the recurrences. Please try again.\"}";
            }

            response(resp);
        }

        [HttpGet]
        public void getIntegrationsShedule()
        {
            string resp = "";
            try
            {
                connectModel();
                List<Integration> integrations = integrationConfigurationModel.getIntegrations();

                resp = Newtonsoft.Json.JsonConvert.SerializeObject(integrations,
                    new JsonSerializerSettings()
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                    });
            }
            catch (Exception e)
            {
                resp = "{\"type\":\"danger\", \"message\":\"Can not be loaded the Integration Shedule. Please try again.\"}";
            }

            response(resp);
        }
    }
}
