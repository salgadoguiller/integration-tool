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
using System.Data;

namespace IntegrationTool.Controllers
{
    [Authorize]
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
            DataTable table = new DataTable();
                     
            try
            {
             
             DeterminateDateIsNullOrNot(reportGenerate, table);                                    
             
             resp = "{\"type\":\"success\", \"message\":\"Report Generate " + Request.Form["value2"] + " Successful.\"}";
            }
            catch (Exception ex)
            {              
                resp = "{\"type\":\"danger\", \"message\":\"Report Generate "+ex.Message+" Unsuccessful. Please try again.\"}";
              
            }
            response(resp);
            
        }

        private void DeterminateDateIsNullOrNot(ReportsGenerate reportGenerate, DataTable table)
        {
            string TimeStartandEnd = "01-01-1901";

            if (string.IsNullOrEmpty(Convert.ToString(Request.Form["start"])))
               ExtractDataToReportWithTimeStartAndEnd(reportGenerate, table, TimeStartandEnd);              
            
            else
               ExtractDataToReport(reportGenerate, table);
            
           
        }

        private void ExtractDataToReport(ReportsGenerate reportGenerate, DataTable table)
        {
            if (Request.Form["value2"].Equals("Integration Logs") || string.IsNullOrEmpty(Request.Form["value2"]))
            {

                table = reportGenerate.ParamToGenerateReportForIntegrationLogs(Convert.ToString(Request.Form["start"]), Convert.ToString(Request.Form["end"]), Convert.ToInt32(Request.Form["IntegrationType"]),
                                                               Convert.ToInt32(Request.Form["IntegrationCategory"]),Convert.ToInt32(Request.Form["OperationWebServices"]), Convert.ToInt32(Request.Form["DatabaseParameter"]));
                generateDocumentForIntegrationLogs(table);
            }

            else
            {
                table = reportGenerate.ParamToGenerateReportForSystemLogs(Convert.ToString(Request.Form["start"]), Convert.ToString(Request.Form["end"]), Convert.ToInt32(Request.Form["IntegrationType"]),
                                                               Convert.ToInt32(Request.Form["IntegrationCategory"]), Convert.ToInt32(Request.Form["OperationWebServices"]), Convert.ToInt32(Request.Form["DatabaseParameter"]));

                generateDocumentForSystemLogs(table);
            }
            
        }

        private void ExtractDataToReportWithTimeStartAndEnd(ReportsGenerate reportGenerate, DataTable table, string TimeStartandEnd)
        {
            if (Request.Form["value2"].Equals("Integration Logs") || string.IsNullOrEmpty(Request.Form["value2"]))
            {
                table = reportGenerate.ParamToGenerateReportForIntegrationLogs(TimeStartandEnd, TimeStartandEnd, Convert.ToInt32(Request.Form["IntegrationType"]), Convert.ToInt32(Request.Form["IntegrationCategory"]),
                                                               Convert.ToInt32(Request.Form["OperationWebServices"]), Convert.ToInt32(Request.Form["DatabaseParameter"]));

                generateDocumentForIntegrationLogs(table);
            }

            else
            {
                table = reportGenerate.ParamToGenerateReportForSystemLogs(TimeStartandEnd, TimeStartandEnd, Convert.ToInt32(Request.Form["IntegrationType"]), Convert.ToInt32(Request.Form["IntegrationCategory"]),
                                                               Convert.ToInt32(Request.Form["OperationWebServices"]), Convert.ToInt32(Request.Form["DatabaseParameter"]));

                generateDocumentForSystemLogs(table);
            }
            
        }

        private void generateDocumentForIntegrationLogs(DataTable table)
        {
            ////                   
            Encrypt decrypt = new Encrypt();
            var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("Integration Logs");

            worksheet.Cell("A1").Value = "Reference Code";
            worksheet.Cell("B1").Value = "Name Integration";
            worksheet.Cell("C1").Value = "Status";
            worksheet.Cell("D1").Value = "Category Integration";
            worksheet.Cell("E1").Value = "Type Integration";
            worksheet.Cell("F1").Value = "Operation Web Services";
            worksheet.Cell("G1").Value = "Database Name";
            worksheet.Cell("H1").Value = "Date Integration";
         
            int contador = 4;
            for (int i = 0; i < table.Rows.Count; i++)
            {
                worksheet.Cell("A" + contador).Value = Convert.ToString(table.Rows[i]["ReferenceCode"]);
                worksheet.Cell("B" + contador).Value = Convert.ToString(table.Rows[i]["IntegrationName"]);                
                worksheet.Cell("C" + contador).Value = Convert.ToString(table.Rows[i]["Status"]);
                worksheet.Cell("D" + contador).Value = Convert.ToString(table.Rows[i]["Name"]);
                worksheet.Cell("E" + contador).Value = Convert.ToString(table.Rows[i]["TypeIntegration"]);
                worksheet.Cell("F" + contador).Value = Convert.ToString(table.Rows[i]["OperationWebServices"]);
                worksheet.Cell("G" + contador).Value = decrypt.decryptData(Convert.ToString(table.Rows[i]["DatabaseName"]));
                worksheet.Cell("H" + contador).Value = Convert.ToString(table.Rows[i]["Date"]);
                contador++; 
            }
            
            worksheet.Columns().AdjustToContents();        
            string path = "C:/Users/cturcios/Desktop/ReportIntegrationLogs" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + ".xlsx";
            
            workbook.SaveAs(path);

            //downloadExcel(path);            
            ////
        }

        private void generateDocumentForSystemLogs(DataTable table)
        {
            ////                   
            Encrypt decrypt = new Encrypt();
            var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("System Logs");

            worksheet.Cell("A1").Value = "Description";
            worksheet.Cell("B1").Value = "Name Integration";
            worksheet.Cell("C1").Value = "Error Date";
            worksheet.Cell("D1").Value = "Category Integration";
            worksheet.Cell("E1").Value = "Type Integration";
            worksheet.Cell("F1").Value = "Operation Web Services";
            worksheet.Cell("G1").Value = "Database Name";
            worksheet.Cell("H1").Value = "Date Integration";

            int contador = 4;
            for (int i = 0; i < table.Rows.Count; i++)
            {
                worksheet.Cell("A" + contador).Value = Convert.ToString(table.Rows[i]["Description"]);
                worksheet.Cell("B" + contador).Value = Convert.ToString(table.Rows[i]["IntegrationName"]);
                worksheet.Cell("C" + contador).Value = Convert.ToString(table.Rows[i]["ErrorDate"]);
                worksheet.Cell("D" + contador).Value = Convert.ToString(table.Rows[i]["Name"]);
                worksheet.Cell("E" + contador).Value = Convert.ToString(table.Rows[i]["TypeIntegration"]);
                worksheet.Cell("F" + contador).Value = Convert.ToString(table.Rows[i]["OperationWebServices"]);
                worksheet.Cell("G" + contador).Value = decrypt.decryptData(Convert.ToString(table.Rows[i]["DatabaseName"]));
                worksheet.Cell("H" + contador).Value = Convert.ToString(table.Rows[i]["IntegrationDate"]);
                contador++;
            }

            worksheet.Columns().AdjustToContents();
            string path = "C:/Users/cturcios/Desktop/ReportSystemLogs" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + ".xlsx";

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
