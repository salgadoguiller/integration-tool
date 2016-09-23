using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace IntegrationTool.Models
{
    public class ReportsGenerate
    {

        public string ParamToGenerateReport(int IntegrationType=0, int IntegrationCategory=0, int OperationWebServices=0, int DatabaseParameter=0, string DateStart="", string DateEnd="",string value="")
        {

            string verificacion = "TypeIntegration: "+Convert.ToString(IntegrationType)+" IntegrationCategory: "+IntegrationCategory+" operationWebServices: "+OperationWebServices+" DateStart: "+DateStart+
                " DateEnd: "+DateEnd+" Value: "+value;

            return verificacion; 

        }
    }
}