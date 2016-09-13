using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Net;
using ClassLibrary;

namespace IntegrationToolService
{
    public class GenerateIntegration
    {
        private string dataConnection;
        private SqlConnection connection;
        private Encrypt decrypt = new Encrypt();
        private Curl curl = new Curl();
        private  WriteFileController writeFileController= new WriteFileController();
       
        public GenerateIntegration(string server = "172.20.33.13", string databaseName = "IntegrationTool", string userId="SISUser",string password="test2016!")
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
            connection.Open();       
        }

        //0.2
        private void CloseConnection()
        {
            connection.Close();           
        }      

        //1
        public void ObtainQueryToVerifyTimeToExecutionIntegration()
        {       
            Console.WriteLine("Hola");
            DateTime datetimeNow = DateTime.Now;
           
            string query =
                "SELECT  dbo.Calendars.IntegrationId,dbo.Calendars.CalendarId,dbo.Calendars.NextExecutionDate," +
                " dbo.Calendars.Emails,dbo.Recurrences.RecurrenceId" +
                " FROM dbo.Calendars INNER JOIN dbo.Recurrences ON dbo.Calendars.RecurrenceId = dbo.Recurrences.RecurrenceId";

            OpenConnection();
            var table = DataTable(query);
            CloseConnection();

           
            VerifyTimeToExecutionIntegration(table, datetimeNow);         
        }

        //2
        private DataTable DataTable(string query)
        {
            SqlCommand sqlCommand = new SqlCommand(query, connection);

            DataTable table = new DataTable();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            sqlDataAdapter.Fill(table);
            return table;
        }

        //3
        private void VerifyTimeToExecutionIntegration(DataTable table, DateTime datetimeNow)
        {
            for (int i = 0; i < table.Rows.Count; i++)
            {
                DateTime nextExecutionDate = Convert.ToDateTime(table.Rows[i]["NextExecutionDate"]);
                if (compareDatetime(datetimeNow, nextExecutionDate))
                {
                    int integrationId = Convert.ToInt32(table.Rows[i]["IntegrationId"]);
                    int recurrenceId = Convert.ToInt32(table.Rows[i]["RecurrenceId"]);
                    int calendarId = Convert.ToInt32(table.Rows[i]["CalendarId"]);
                
                    updateTimeToExecuteIntegration(calendarId, setNewTimeToExecuteIntegration(recurrenceId, nextExecutionDate));
                    executeIntegration(integrationId);
                }
            }
        }

        //3.1
        private static bool compareDatetime(DateTime datetimeNow, DateTime nextExecutionDate)
        {
            return datetimeNow.ToString("yyyy-MM-dd-HH").Equals(nextExecutionDate.ToString("yyyy-MM-dd-HH"));
        }

        //4
        private DateTime setNewTimeToExecuteIntegration(int recurrenceId, DateTime nextExecutionDate)
        {
            DateTime nexTime = DateTime.Now;

            int recurrenceHourly = 1;
            int dailyRecurrence = 2;
            int recurrenceEveryWeek = 3;
            int monthlyRecurrence = 4;

            if (recurrenceId == recurrenceHourly)
                nexTime = nextExecutionDate.AddHours(1);

            else
                if (recurrenceId == dailyRecurrence)
                    nexTime = nextExecutionDate.AddDays(1);

                else
                    if (recurrenceId == recurrenceEveryWeek)
                        nexTime = nextExecutionDate.AddDays(7);

                    else if (recurrenceId == monthlyRecurrence)
                        nexTime = nextExecutionDate.AddMonths(1);

            return nexTime;
        }

        //5
        private void updateTimeToExecuteIntegration(int calendarId, DateTime nextExecutionDate)
        {
            string query =
              "Update Calendars set NextExecutionDate='" + nextExecutionDate + "' where CalendarId=" + calendarId;

            OpenConnection();
            SqlCommand sqlCommand = new SqlCommand(query, connection);
            sqlCommand.ExecuteNonQuery();
            CloseConnection();
        }  

        //6
        private void executeIntegration(int integrationId)
        {     
           string resultQueryAndNameIntegration = obtainDatabaseParameters(integrationId);
           string[] result = resultQueryAndNameIntegration.Split('|');
           string location= obtainLocationFileToSave(integrationId);
           string fullPath = writeFileController.writeFileinFlatFile(result[0], location, result[1]);
           string webServicesParameters = obtainWebService(integrationId);
           
           parseWebServicesResult(webServicesParameters,fullPath);
         
        }

        //7
        private string obtainDatabaseParameters(int integrationId)
        {
            DataBaseFactory dataBase = new DataBaseFactory();


            string query =
                "SELECT  dbo.DatabaseParameters.Ip, dbo.DatabaseParameters.Port, dbo.DatabaseParameters.Instance, dbo.DatabaseParameters.Name, dbo.DatabaseParameters.Username," +
                " dbo.DatabaseParameters.Password, dbo.Engines.Name AS NameEngine, dbo.Integrations.IntegrationId" +
                " FROM dbo.DatabaseParameters INNER JOIN" +
                " dbo.Engines ON dbo.DatabaseParameters.EngineId = dbo.Engines.EngineId INNER JOIN" +
                " dbo.Integrations ON dbo.DatabaseParameters.DatabaseParametersId = dbo.Integrations.DatabaseParametersId" +
                " where IntegrationId =" + integrationId;

            DataTable table = DataTable(query);

            InterfaceDatabase iNterfaceDatabase = dataBase.createInstanceDataBase(decrypt.decryptData(Convert.ToString(table.Rows[0]["Ip"])), decrypt.decryptData(Convert.ToString(table.Rows[0]["Port"])), decrypt.decryptData(Convert.ToString(table.Rows[0]["Name"])),
            decrypt.decryptData(Convert.ToString(table.Rows[0]["Instance"])), decrypt.decryptData(Convert.ToString(table.Rows[0]["Username"])), ""/*decrypt.decryptData(Convert.ToString(table.Rows[0]["Password"]))*/, Convert.ToString(table.Rows[0]["NameEngine"]));

            return executeQueryInDatabase(iNterfaceDatabase, integrationId);
        }

        //8
        private string executeQueryInDatabase(InterfaceDatabase iNterfaceDatabase, int integrationId)
        {
            string recoverQueryId = "SELECT QueryId FROM dbo.Integrations where IntegrationId=" + integrationId;
            DataTable table = DataTable(recoverQueryId);

            int queryId = Convert.ToInt32(table.Rows[0]["QueryId"]);

            string query = "SELECT dbo.IntegrationsType.Name, dbo.Queries.Query FROM dbo.IntegrationsType INNER JOIN dbo.Queries" +
                           " ON dbo.IntegrationsType.IntegrationTypeId = dbo.Queries.IntegrationTypeId where QueryId=" + queryId;

            table = DataTable(query);

            iNterfaceDatabase.openConnection();
            string resultQuery = iNterfaceDatabase.executeQuery(decrypt.decryptData(Convert.ToString(table.Rows[0]["Query"])));
            iNterfaceDatabase.closeConnection();

            return resultQuery + "|" + Convert.ToString(table.Rows[0]["Name"]);
        }

        //9
        private string obtainLocationFileToSave(int integrationId)
        {
            string query = "SELECT  dbo.FlatFilesParameters.Location FROM dbo.FlatFilesParameters INNER JOIN" +
                           " dbo.Integrations ON dbo.FlatFilesParameters.FlatFileParameterId = dbo.Integrations.FlatFileParameterId" +
                           " where IntegrationId=" + integrationId;

            DataTable table = DataTable(query);  
            return decrypt.decryptData(Convert.ToString(table.Rows[0]["Location"]));
        }

        //10
        private string obtainWebService(int integrationId)
        {
            string recoverWebServiceId = "SELECT WebServiceId FROM dbo.Integrations where IntegrationId=" + integrationId;
            DataTable table = DataTable(recoverWebServiceId);
            int webServiceId = Convert.ToInt32(table.Rows[0]["WebServiceId"]);

            string query = "SELECT Endpoint, Username, Password FROM dbo.WebServices where WebServiceId=" + webServiceId;
            table = DataTable(query);

            string enpoint = decrypt.decryptData(Convert.ToString(table.Rows[0]["Endpoint"]));
            string username = decrypt.decryptData(Convert.ToString(table.Rows[0]["Username"]));
            string password = decrypt.decryptData(Convert.ToString(table.Rows[0]["Password"]));

            return enpoint+"|"+username+"|"+password;
        }

        //11
        private void parseWebServicesResult(string webServicesParameters, string fullPath)
        {
            string[] webServices = webServicesParameters.Split('|');

            string curlCommand = "curl -w '%{http_code}' -H 'Content-Type:text/plain' --data-binary '"+fullPath+ "' -u "+webServices[2]+":"+webServices[1]+" --url "+webServices[0];
           
            Console.WriteLine(curlCommand);
            curl.IntegrationWithCurl(curlCommand);
        }       
    }
}
