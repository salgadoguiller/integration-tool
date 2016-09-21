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
    public class LogsController : Controller
    {

        private LogsConfiguration logsConfigurationModel;
        private Encrypt encryptor;

        private void connectModel()
        {
            logsConfigurationModel = new LogsConfiguration();
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
        // Lista parametros del sistema.
        // ================================================================================================================

        [HttpGet]
        public ActionResult listSystemLogs()
        {
            return View();
        }


        [HttpGet]
        public void getListSystemLogs()
        {
            string resp = "";
            try
            {
                connectModel();
                
                List<SystemLog> systemLogs = logsConfigurationModel.getSystemLogs();

                resp = Newtonsoft.Json.JsonConvert.SerializeObject(systemLogs,
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

        
    }
}
