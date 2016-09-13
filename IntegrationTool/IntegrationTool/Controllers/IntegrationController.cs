using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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

        [HttpGet]
        public ActionResult manual()
        {
            return View();
        }

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

                integrationConfigurationModel.saveIntegration(/*Convert.ToInt32(Request.Form["UserId"])*/ 1,
                                                                Convert.ToInt32(Request.Form["WebServiceId"]),
                                                                Convert.ToInt32(Request.Form["DatabaseParametersId"]),
                                                                /*Convert.ToInt32(Request.Form["ServerSMTPParametersId"])*/ 1,
                                                                /*Convert.ToInt32(Request.Form["FlatFileId"])*/ 1,
                                                                Convert.ToInt32(Request.Form["FlatFileParameterId"]),
                                                                Convert.ToInt32(Request.Form["IntegrationTypeId"]),
                                                                Convert.ToInt32(Request.Form["QueryId"]),
                                                                queryParameters);

                resp = "{\"type\":\"success\", \"message\":\"Integration Successful Stored.\"}";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                // resp = "{\"type\":\"danger\", \"message\":\"" + ex.Message + "\"}";
                // resp = "{\"type\":\"danger\", \"message\":\"Configuration Active Directory Unsuccessful. Please try again.\"}";
            }


            response(resp);
        }

        [HttpGet]
        public ActionResult automatic()
        {
            return View();
        }
    }
}
