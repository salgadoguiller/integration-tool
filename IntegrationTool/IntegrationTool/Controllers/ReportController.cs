using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using IntegrationTool.Models;
//Para el manejo de Archivos
using System.IO;
//Clases necesarias de iTextSharp
using iTextSharp;
using iTextSharp.text.pdf;
using iTextSharp.text;
//Para la creacion de un excel
using DocumentFormat.OpenXml;
using ClosedXML.Excel;
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


        [HttpPost]
        public void getDocumentReport()
        {
            string resp = "";
            string verificacion ="";
            ReportsGenerate reportGenerate = new ReportsGenerate();
                     
            try
            {

             verificacion= reportGenerate.ParamToGenerateReport(Convert.ToInt32(Request.Form["IntegrationType"]),Convert.ToInt32(Request.Form["IntegrationCategory"]),Convert.ToInt32(Request.Form["OperationWebServices"]),
                                                   Convert.ToInt32(Request.Form["DatabaseParameter"]),Request.Form["start"], Request.Form["end"], Request.Form["value2"]);

             generateDocument();

                resp = "{\"type\":\"success\", \"message\":\"Report Generate Successful.\"}";
            }
            catch (Exception ex)
            {              
                resp = "{\"type\":\"danger\", \"message\":\"Report Generate "+ex.Message+" Unsuccessful. Please try again.\"}";
            }
            //response(resp);
        }

        private void generateDocument()
        {
            ////                   
            var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("Integration");

            worksheet.Cell("A1").Value = "Reference Code";
            worksheet.Cell("B1").Value = "Date";
            worksheet.Cell("C1").Value = "integration Id";
            worksheet.Cell("D1").Value = "Status";

            connectModel();

            List<IntegrationLog> integrationLog2 = ReportsConfigurationModel.getIntegrationLog();
                               
            int contador = 4;
            foreach (IntegrationLog integration2 in integrationLog2)
            {

                worksheet.Cell("A" + contador).Value = integration2.ReferenceCode;
                worksheet.Cell("B" + contador).Value = integration2.Date.ToString("d");
                worksheet.Cell("C" + contador).Value = integration2.IntegrationId;
                worksheet.Cell("D" + contador).Value = integration2.Status;
               contador++;
            }              
            
            worksheet.Columns().AdjustToContents();

            string fechaActual = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
            string path = "C:/Users/cturcios/Desktop/ReporteIntegration.xlsx";
            
            workbook.SaveAs(path);

            //downloadExcel(path);            
            ////
        }

        private void downloadExcel(string path)
        {
            Response.Clear();
            Response.ClearContent();
            Response.ClearHeaders();
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.Flush();
            Response.TransmitFile(path);
            Response.End();
        }
    }
}
