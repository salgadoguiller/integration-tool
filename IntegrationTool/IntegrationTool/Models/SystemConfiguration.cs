using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IntegrationTool.Models
{
    public class SystemConfiguration
    {
        private IntegrationToolEntities SystemConfigurationDB;

        public SystemConfiguration()
        {
            SystemConfigurationDB = new IntegrationToolEntities();
        }

        // ================================================================================================================
        // Obtener parametros del sistema.
        // ================================================================================================================
        public List<ActiveDirectoryParameter> getActiveDirectories()
        {
            List<ActiveDirectoryParameter> activeDirectories = (from ad in SystemConfigurationDB.ActiveDirectoryParameters
                                                select ad).ToList();
            return activeDirectories;
        }

        public List<ServerSMTPParameter> getServersSMTP()
        {
            List<ServerSMTPParameter> serverSmtp = (from server in SystemConfigurationDB.ServerSMTPParameters
                                                    select server).ToList();
            return serverSmtp;
        }

        public List<Query> getQueries()
        {
            List<Query> queries = (from query in SystemConfigurationDB.Queries
                                                 select query).ToList();
            return queries;
        }

        public List<FlatFileParameter> getFlatFiles()
        {
            List<FlatFileParameter> flatFiles = (from ff in SystemConfigurationDB.FlatFileParameters
                                                 select ff).ToList();
            return flatFiles;
        }

        public List<DatabaseParameter> getDatabases()
        {
            List<DatabaseParameter> databases = (from db in SystemConfigurationDB.DatabaseParameters
                                                 select db).ToList();
            return databases;
        }

        public List<WebService> getWebServices()
        {
            List<WebService> webServices = (from ws in SystemConfigurationDB.WebServices
                                            select ws).ToList();
            return webServices;
        }

        public List<Header> getHeaders()
        {
            List<Header> headers = SystemConfigurationDB.Headers.ToList();

            return headers;
        }

        public List<Engine> getDataBaseEngines()
        {
            List<Engine> engines = (from dbEngine in SystemConfigurationDB.Engines
                                    select dbEngine).ToList();
            return engines;
        }

        public List<QueriesType> getTypeQueries()
        {
            List<QueriesType> queries = (from queryType in SystemConfigurationDB.QueriesTypes
                                         select queryType).ToList();
            return queries;
        }

        public ActiveDirectoryParameter getActiveDirectory(int id)
        {
            ActiveDirectoryParameter activeDirectory = SystemConfigurationDB.ActiveDirectoryParameters.Where(param => param.ActiveDirectoryId == id).ToList()[0];
            return activeDirectory;
        }

        public DatabaseParameter getDatabase(int id)
        {
            DatabaseParameter dataBase = SystemConfigurationDB.DatabaseParameters.Where(param => param.DatabaseParametersId == id).ToList()[0];
            return dataBase;
        }

        public FlatFileParameter getFlatFile(int id)
        {
            FlatFileParameter flatFile = SystemConfigurationDB.FlatFileParameters.Where(param => param.FlatFileParametersId == id).ToList()[0];
            return flatFile;
        }

        public Header getHeader(int id)
        {
            Header header = SystemConfigurationDB.Headers.Where(param => param.HeaderId == id).ToList()[0];
            return header;
        }

        public Query getQuery(int id)
        {
            Query query = SystemConfigurationDB.Queries.Where(param => param.QueryId == id).ToList()[0];
            return query;
        }

        public ServerSMTPParameter getServerSMTP(int id)
        {
            ServerSMTPParameter serverSMTP = SystemConfigurationDB.ServerSMTPParameters.Where(param => param.ServerSMTPParametersId == id).ToList()[0];
            return serverSMTP;
        }

        public WebService getWebService(int id)
        {
            WebService webService = SystemConfigurationDB.WebServices.Where(param => param.WebServiceId == id).ToList()[0];
            return webService;
        }

        // ================================================================================================================
        // Almacenar parametros del sistema.
        // ================================================================================================================
        public void saveActiveDirectory(string domain, string path)
        {
            ActiveDirectoryParameter ad = new ActiveDirectoryParameter();
            ad.ADPath = domain;
            ad.ADDomain = path;

            SystemConfigurationDB.ActiveDirectoryParameters.Add(ad);
            SystemConfigurationDB.SaveChanges();
        }

        public void saveServerSMPT(string NameServerSMTP, string Port, string UsernameSMTP, string PasswordSMTP)
        {           
            ServerSMTPParameter serverSmtp = new ServerSMTPParameter();
            serverSmtp.NameServerSMTP = NameServerSMTP;
            serverSmtp.Port = Port;
            serverSmtp.UsernameSMTP = UsernameSMTP;
            serverSmtp.PasswordSMTP = PasswordSMTP;

            SystemConfigurationDB.ServerSMTPParameters.Add(serverSmtp);
            SystemConfigurationDB.SaveChanges();      
        }

        public void saveQuery(string queryUser,string queryTypeUser)
        {        
            Query query = new Query();
            query.Query1 = queryUser;
            query.QueryTypeId = Convert.ToInt32(queryTypeUser);

            SystemConfigurationDB.Queries.Add(query);
            SystemConfigurationDB.SaveChanges();
        }

        public void saveFlatFiles(string location)
        {           
            FlatFileParameter flatFile = new FlatFileParameter();

            flatFile.Location = location;
           
            SystemConfigurationDB.FlatFileParameters.Add(flatFile);
            SystemConfigurationDB.SaveChanges();
        }

        public void saveDatabase(string ip, string instance, string name, string username, string password, string engineId, string port)
        {
            DatabaseParameter db = new DatabaseParameter();
            db.Ip = ip;
            db.Instance = instance;
            db.Name = name;
            db.Username = username;
            db.Password = password;
            db.Port = port;

            int intEngineId = Convert.ToInt32(engineId);

            // Engine engine = SystemConfigurationDB.Engines.Where(param => param.EngineId == intEngineId).ToList()[0];

            db.EngineId = intEngineId;

            SystemConfigurationDB.DatabaseParameters.Add(db);
            SystemConfigurationDB.SaveChanges();
        }

        public void saveWebService(string endpoint, string username, string password)
        {
            WebService webService = new WebService();
            webService.Endpoint = endpoint;
            webService.Username = username;
            webService.Password = password;

            SystemConfigurationDB.WebServices.Add(webService);
            SystemConfigurationDB.SaveChanges();
        }

        public void saveHeaders(string queryTypeId, string name)
        {
            string[] headersName = name.Split('|');

            foreach (string headerName in headersName)
            {
                Header header = new Header();
                header.Name = headerName;

                SystemConfigurationDB.Headers.Add(header);
                SystemConfigurationDB.SaveChanges();

                HeadersQueryType headerQueryType = new HeadersQueryType();
                headerQueryType.QueryTypeId = Convert.ToInt32(queryTypeId);
                headerQueryType.HeaderId = header.HeaderId;

                SystemConfigurationDB.HeadersQueryTypes.Add(headerQueryType);
                SystemConfigurationDB.SaveChanges();
            }
        }

        // ================================================================================================================
        // Actualizar parametros del sistema.
        // ================================================================================================================
        public void updateActiveDirectory(int id, string domain, string path)
        {
            ActiveDirectoryParameter ad = SystemConfigurationDB.ActiveDirectoryParameters.Where(param => param.ActiveDirectoryId == id).ToList()[0];
            ad.ADPath = domain;
            ad.ADDomain = path;

            SystemConfigurationDB.SaveChanges();
        }

        public void updateDatabase(int id, string ip, string instance, string name, string username, string password, int engineId, string port)
        {
            DatabaseParameter db = SystemConfigurationDB.DatabaseParameters.Where(param => param.DatabaseParametersId == id).ToList()[0];
            db.Ip = ip;
            db.Instance = instance;
            db.Name = name;
            db.Username = username;
            db.Password = password;
            db.Port = port;
            db.EngineId = engineId;

            SystemConfigurationDB.SaveChanges();
        }

        public void updateFlatFile(int id, string location)
        {
            FlatFileParameter flatFile = SystemConfigurationDB.FlatFileParameters.Where(param => param.FlatFileParametersId == id).ToList()[0];

            flatFile.Location = location;

            SystemConfigurationDB.SaveChanges();
        }

        public void updateHeader(int id, int queryTypeId, string name)
        {

        }

        public void updateQuery(int id, string queryString, int queryTypeId)
        {
            Query query = SystemConfigurationDB.Queries.Where(param => param.QueryId == id).ToList()[0];
            query.Query1 = queryString;
            query.QueryTypeId = queryTypeId;

            SystemConfigurationDB.SaveChanges();
        }

        public void updateServerSMPT(int id, string NameServerSMTP, string Port, string UsernameSMTP, string PasswordSMTP)
        {
            ServerSMTPParameter serverSmtp = SystemConfigurationDB.ServerSMTPParameters.Where(param => param.ServerSMTPParametersId == id).ToList()[0];
            serverSmtp.NameServerSMTP = NameServerSMTP;
            serverSmtp.Port = Port;
            serverSmtp.UsernameSMTP = UsernameSMTP;
            serverSmtp.PasswordSMTP = PasswordSMTP;

            SystemConfigurationDB.SaveChanges();
        }

        public void updateWebService(int id, string endpoint, string username, string password)
        {
            WebService webService = SystemConfigurationDB.WebServices.Where(param => param.WebServiceId == id).ToList()[0];
            webService.Endpoint = endpoint;
            webService.Username = username;
            webService.Password = password;

            SystemConfigurationDB.SaveChanges();
        }

        // ================================================================================================================
        // Eliminar parametros del sistema.
        // ================================================================================================================
        public void deleteActiveDirectory(int activeDirectoryId)
        {
            ActiveDirectoryParameter activeDirectory = SystemConfigurationDB.ActiveDirectoryParameters.Where(param => param.ActiveDirectoryId == activeDirectoryId).ToList()[0];

            SystemConfigurationDB.ActiveDirectoryParameters.Remove(activeDirectory);
            SystemConfigurationDB.SaveChanges();
        }

        public void deleteDataBase(int dataBaseId)
        {
            DatabaseParameter database = SystemConfigurationDB.DatabaseParameters.Where(param => param.DatabaseParametersId == dataBaseId).ToList()[0];

            SystemConfigurationDB.DatabaseParameters.Remove(database);
            SystemConfigurationDB.SaveChanges();
        }

        public void deleteFlatFile(int flatFileIdId)
        {
            FlatFileParameter flatFile = SystemConfigurationDB.FlatFileParameters.Where(param => param.FlatFileParametersId == flatFileIdId).ToList()[0];

            SystemConfigurationDB.FlatFileParameters.Remove(flatFile);
            SystemConfigurationDB.SaveChanges();
        }

        public void deleteHeader(int headerId)
        {
            Header header = SystemConfigurationDB.Headers.Where(param => param.HeaderId == headerId).ToList()[0];

            SystemConfigurationDB.Headers.Remove(header);
            SystemConfigurationDB.SaveChanges();
        }

        public void deleteQuery(int queryId)
        {
            Query query = SystemConfigurationDB.Queries.Where(param => param.QueryId == queryId).ToList()[0];

            SystemConfigurationDB.Queries.Remove(query);
            SystemConfigurationDB.SaveChanges();
        }

        public void deleteServerSMTP(int serverSMTPId)
        {
            ServerSMTPParameter serverSMTP = SystemConfigurationDB.ServerSMTPParameters.Where(param => param.ServerSMTPParametersId == serverSMTPId).ToList()[0];

            SystemConfigurationDB.ServerSMTPParameters.Remove(serverSMTP);
            SystemConfigurationDB.SaveChanges();
        }

        public void deleteWebService(int webServiceId)
        {
            WebService webService = SystemConfigurationDB.WebServices.Where(param => param.WebServiceId == webServiceId).ToList()[0];

            SystemConfigurationDB.WebServices.Remove(webService);
            SystemConfigurationDB.SaveChanges();
        }
    }
}