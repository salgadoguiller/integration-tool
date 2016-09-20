using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Net;

namespace ClassLibrary
{
    public class Integration
    {       
        private string dataConnection;
        private SqlConnection connection;
        private Encrypt decrypt = new Encrypt();
        private Curl curl = new Curl();
        private WriteFileController writeFileController = new WriteFileController();
        private string emails = "";
        private string location = "";


        public Integration(string server = "172.20.33.13", string databaseName = "IntegrationTool", string userId = "SISUser", string password = "test2016!")
        {
            this.dataConnection = "Data Source=" + server + ";Initial Catalog=" + databaseName + ";User ID=" + userId + ";Password=" + password;
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

        //2
        private DataTable DataTable(string query)
        {
            SqlCommand sqlCommand = new SqlCommand(query, connection);

            DataTable table = new DataTable();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            sqlDataAdapter.Fill(table);
            return table;
        }

        public void initIntegrationAutomatic(int integrationId, string emails)
        {
            this.emails = emails;
            executeIntegration(integrationId);
        }

        //Desde este metodo partiria para una integracion manual, sin hacer los metodos previos
        //6
        private void executeIntegration(int integrationId)
        {
            string resultQueryAndNameIntegration = obtainDatabaseParameters(integrationId);
            string[] result = resultQueryAndNameIntegration.Split('$');

            location = obtainLocationFileToSave(integrationId);
            string fullPathMoreNameFile = writeFileController.writeFileinFlatFile(result[0], location, result[1]);
            string webServicesParameters = obtainWebService(integrationId);

            string[] splitNameAndFullPath = fullPathMoreNameFile.Split('|');
            parseWebServicesResult(webServicesParameters, splitNameAndFullPath[0]);
            insertNameFile(splitNameAndFullPath[1]);
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

            string instance = (Convert.ToString(table.Rows[0]["Instance"]) != null) ? decrypt.decryptData(Convert.ToString(table.Rows[0]["Instance"])) : "";
            string port = (Convert.ToString(table.Rows[0]["Port"]) != null) ? decrypt.decryptData(Convert.ToString(table.Rows[0]["Port"])) : "";
            string password = (Convert.ToString(table.Rows[0]["Password"]) != null) ? decrypt.decryptData(Convert.ToString(table.Rows[0]["Password"])) : "";

            InterfaceDatabase iNterfaceDatabase = dataBase.createInstanceDataBase(decrypt.decryptData(Convert.ToString(table.Rows[0]["Ip"])), port, decrypt.decryptData(Convert.ToString(table.Rows[0]["Name"])),
            instance, decrypt.decryptData(Convert.ToString(table.Rows[0]["Username"])), password, Convert.ToString(table.Rows[0]["NameEngine"]));

            return executeQueryInDatabase(iNterfaceDatabase, integrationId);
        }

        //8
        private string executeQueryInDatabase(InterfaceDatabase iNterfaceDatabase, int integrationId)
        {
            string recoverQueryId = "SELECT QueryId FROM dbo.Integrations where IntegrationId=" + integrationId;
            DataTable table = DataTable(recoverQueryId);

            int queryId = Convert.ToInt32(table.Rows[0]["QueryId"]);

            string query = "SELECT dbo.Queries.Query, dbo.QueryParameters.Name, dbo.QueryParameters.Value FROM  dbo.Queries CROSS JOIN dbo.QueryParameters" +
            " where QueryParameters.IntegrationId=" + integrationId + " and Queries.QueryId=" + queryId;

            table = DataTable(query);

            string queryToDatabase = ReplaceQueryParameters(table);

            iNterfaceDatabase.openConnection();
            string resultQuery = iNterfaceDatabase.executeQuery(queryToDatabase);
            iNterfaceDatabase.closeConnection();

            string nameIntegration = ReturnNameIntegration(integrationId);

            return resultQuery + "$" + nameIntegration;
        }

        //8.1
        private string ReplaceQueryParameters(DataTable table)
        {
            string query = decrypt.decryptData(Convert.ToString(table.Rows[0]["Query"]));

            for (int i = 0; i < table.Rows.Count; i++)
            {
                query = query.Replace(Convert.ToString(table.Rows[i]["Name"]), Convert.ToString(table.Rows[i]["Value"]));
            }

            return query;
        }

        //8.2
        private string ReturnNameIntegration(int integrationId)
        {
            string query = "SELECT IntegrationTypeId FROM dbo.Integrations where IntegrationId=" + integrationId;
            DataTable table = DataTable(query);

            string query2 = "SELECT Name FROM dbo.IntegrationsType where IntegrationTypeId=" + Convert.ToInt32(table.Rows[0]["IntegrationTypeId"]);
            table = DataTable(query2);

            return Convert.ToString(table.Rows[0]["Name"]);
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
            string query = "SELECT  dbo.WebServices.Endpoint, dbo.IntegrationsType.Identifier, dbo.OperationsWebServices.Identifier AS IdentifierWebServices, dbo.WebServices.Username, dbo.WebServices.Password" +
                           " FROM dbo.Integrations INNER JOIN" +
                           " dbo.IntegrationsType ON dbo.Integrations.IntegrationTypeId = dbo.IntegrationsType.IntegrationTypeId INNER JOIN" +
                           " dbo.WebServices ON dbo.Integrations.WebServiceId = dbo.WebServices.WebServiceId INNER JOIN" +
                           " dbo.OperationsWebServices ON dbo.Integrations.OperationWebServiceId = dbo.OperationsWebServices.OperationWebServiceId" +
                           " where IntegrationId=" + integrationId;

            DataTable table = DataTable(query);

            string endpoint = decrypt.decryptData(Convert.ToString(table.Rows[0]["Endpoint"]));
            string identifier = Convert.ToString(table.Rows[0]["Identifier"]);
            string identifierWebServices = Convert.ToString(table.Rows[0]["IdentifierWebServices"]);
            string username = decrypt.decryptData(Convert.ToString(table.Rows[0]["Username"]));
            string password = decrypt.decryptData(Convert.ToString(table.Rows[0]["Password"]));

            return endpoint + "|" + identifier + "|" + identifierWebServices + "|" + password + "|" + username;
        }

        //11
        private void parseWebServicesResult(string webServicesParameters, string fullPath)
        {
            string[] webServices = webServicesParameters.Split('|');

            string curlCommand = "curl -w '%{http_code}' -H Content-Type:text/plain --data-binary @" + fullPath + " -u " + webServices[4] + ":" + webServices[3] + " --url " + webServices[0] + webServices[1] + "/" + webServices[2] + "> " + location + "/LogIntegration.txt";

            Console.WriteLine(curlCommand);
            curl.IntegrationWithCurl(curlCommand);

            sendEmail();
        }

        //12
        private void sendEmail()
        {
            if (emails != null || !emails.Equals(""))
            {
                SendEmail email = new SendEmail();

                string query = "SELECT NameServerSMTP, Port, UsernameSMTP, PasswordSMTP, EmailFrom, Subject, Body FROM dbo.ServerSMTPParameters";
                DataTable table = DataTable(query);

                email.sendMail(decrypt.decryptData(Convert.ToString(table.Rows[0]["UsernameSMTP"])), decrypt.decryptData(Convert.ToString(table.Rows[0]["PasswordSMTP"])), decrypt.decryptData(Convert.ToString(table.Rows[0]["NameServerSMTP"])),
                               decrypt.decryptData(Convert.ToString(table.Rows[0]["Port"])), decrypt.decryptData(Convert.ToString(table.Rows[0]["EmailFrom"])), emails, decrypt.decryptData(Convert.ToString(table.Rows[0]["Subject"])),
                               decrypt.decryptData(Convert.ToString(table.Rows[0]["Body"])));
            }
        }

        //13
        private void insertNameFile(string NameFile)
        {
            string query = "insert into FlatFiles (Name) values('" + NameFile + "')";

            OpenConnection();
            SqlCommand sqlCommand = new SqlCommand(query, connection);
            sqlCommand.ExecuteNonQuery();
            CloseConnection();
        }
    }
}
