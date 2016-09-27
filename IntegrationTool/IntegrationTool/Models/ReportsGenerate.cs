using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using ClassLibrary;
using System.Linq;

namespace IntegrationTool.Models
{
    public class ReportsGenerate
    {       
        private string dataConnection;
        private SqlConnection connection;
        private Integration integration = new Integration();
        private Encrypt decrypt = new Encrypt();

        public ReportsGenerate(string server = "172.20.33.13", string databaseName = "IntegrationTool", string userId = "SISUser", string password = "test2016!")
        {
            this.dataConnection = "Data Source=" + server + ";Initial Catalog=" + databaseName + ";User ID="+userId+";Password="+password;  
            InitialConnection(this.dataConnection);
        }

        //0
        private void InitialConnection(string dataConnection)
        {
            connection = new SqlConnection();
            connection.ConnectionString = dataConnection;
        }

        //0.1
        private void OpenConnection()
        {
            try
            {
                connection.Open();      
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                Console.WriteLine(e.Message);
            }           
        }

        //0.2
        private void CloseConnection()
        {
            try
            {
                connection.Close();    
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                Console.WriteLine(e.Message);
            }                 
        }      

        public DataTable ParamToGenerateReport(int IntegrationType=0, int IntegrationCategory=0, int OperationWebServices=0, int DatabaseParameter=0, string DateStart="", string DateEnd="",string value="")
        {
            string integrationCategoryDecision = "";
            string integrationTypeDecision = "";
            string operationWebServicesDecision = "";
            string DatabaseParameterDecision ="";

            switch (IntegrationType)
            {
                case 0:
                    integrationTypeDecision = "1=1";
                    break;
                default:
                    integrationTypeDecision = "IntegrationsType.IntegrationTypeId ="+IntegrationType;
                    break;             
            }

            switch (IntegrationCategory)
            {
                case 0:
                    integrationCategoryDecision = "1=1";
                    break;
                default:
                    integrationCategoryDecision = "IntegrationCategories.IntegrationCategoryId ="+IntegrationCategory;
                    break;             
            }

            

            string verificacion = "TypeIntegration: "+Convert.ToString(IntegrationType)+" IntegrationCategory: "+IntegrationCategory+" operationWebServices: "+OperationWebServices+" DateStart: "+DateStart+
                " DateEnd: "+DateEnd+" Value: "+value;

            string query = "SELECT  dbo.IntegrationCategories.Name, dbo.IntegrationsType.Name AS TypeIntegration, dbo.OperationsWebServices.Name AS OperationWebServices,"+
                           " dbo.DatabaseParameters.Name AS DatabaseName, dbo.IntegrationLogs.ReferenceCode,"+
                           " dbo.IntegrationLogs.Date, dbo.IntegrationLogs.Status"+
                           " FROM dbo.Integrations INNER JOIN"+
                           " dbo.IntegrationCategories ON dbo.Integrations.IntegrationCategoryId = dbo.IntegrationCategories.IntegrationCategoryId INNER JOIN"+
                           " dbo.IntegrationsType ON dbo.Integrations.IntegrationTypeId = dbo.IntegrationsType.IntegrationTypeId INNER JOIN"+
                           " dbo.OperationsWebServices ON dbo.Integrations.OperationWebServiceId = dbo.OperationsWebServices.OperationWebServiceId INNER JOIN"+
                           " dbo.DatabaseParameters ON dbo.Integrations.DatabaseParametersId = dbo.DatabaseParameters.DatabaseParametersId INNER JOIN"+
                           " dbo.IntegrationLogs ON dbo.Integrations.IntegrationId = dbo.IntegrationLogs.IntegrationId"+
                           " where "+integrationCategoryDecision;
                    
            OpenConnection();         
            var table = DataTable(query);
            CloseConnection();

            return table;
         
        }

        //2
        private DataTable DataTable(string query)
        {
            SqlCommand sqlCommand = new SqlCommand(query, connection);
            DataTable table = new DataTable();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);

            try
            {
                sqlDataAdapter.Fill(table);
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                Console.WriteLine(e.Message);
            }

            return table;            
        }

        public DataTable PathToSaveReport()
        {
            string query = "Select Location";

            OpenConnection();
            var table = DataTable(query);
            CloseConnection();

            return table;
        }
    }
}