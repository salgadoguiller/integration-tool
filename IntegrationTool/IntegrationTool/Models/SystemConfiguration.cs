using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IntegrationTool.Models
{
    public class SystemConfiguration
    {
        private IntegrationToolEntities systemConfigurationDB;

        public SystemConfiguration()
        {
            systemConfigurationDB = new IntegrationToolEntities();
        }

        // ================================================================================================================
        // Obtener parametros del sistema.
        // ================================================================================================================
        public List<ActiveDirectoryParameter> getActiveDirectories()
        {
            List<ActiveDirectoryParameter> activeDirectories = (from ad in systemConfigurationDB.ActiveDirectoryParameters
                                    select ad).ToList();
            return activeDirectories;
        }

        public List<ServerSMTPParameter> getServersSMTP()
        {
            List<ServerSMTPParameter> serverSmtp = (from server in systemConfigurationDB.ServerSMTPParameters
                            select server).ToList();
            return serverSmtp;
        }

        public List<Query> getQueries()
        {
            List<Query> queries = (from query in systemConfigurationDB.Queries
                        select query).ToList();
            return queries;
        }

        public List<FlatFilesParameter> getFlatFiles()
        {
            List<FlatFilesParameter> flatFiles = (from ff in systemConfigurationDB.FlatFilesParameters
                        select ff).ToList();
            return flatFiles;
        }

        public List<DatabaseParameter> getDatabases()
        {
            List<DatabaseParameter> databases = (from db in systemConfigurationDB.DatabaseParameters
                            select db).ToList();
            return databases;
        }

        public List<WebService> getWebServices()
        {
            List<WebService> webServices = (from ws in systemConfigurationDB.WebServices
                                            select ws).ToList();
            return webServices;
        }

        public List<Engine> getDataBaseEngines()
        {
            List<Engine> engines = (from dbEngine in systemConfigurationDB.Engines
                        select dbEngine).ToList();
            return engines;
        }

        public List<IntegrationsType> getIntegrationsType()
        {
            List<IntegrationsType> integrationsType = (from it in systemConfigurationDB.IntegrationsTypes
                                    select it).ToList();
            return integrationsType;
        }

        public List<Key> getKeys()
        {
            List<Key> keys = (from k in systemConfigurationDB.Keys
                                select k).ToList();
            return keys;
        }

        public ActiveDirectoryParameter getActiveDirectory(int id)
        {
            ActiveDirectoryParameter activeDirectory = systemConfigurationDB.ActiveDirectoryParameters.Where(param => param.ActiveDirectoryId == id).ToList()[0];
            return activeDirectory;
        }

        public DatabaseParameter getDatabase(int id)
        {
            DatabaseParameter dataBase = systemConfigurationDB.DatabaseParameters.Where(param => param.DatabaseParametersId == id).ToList()[0];
            return dataBase;
        }

        public FlatFilesParameter getFlatFile(int id)
        {
            FlatFilesParameter flatFile = systemConfigurationDB.FlatFilesParameters.Where(param => param.FlatFileParameterId == id).ToList()[0];
            return flatFile;
        }

        public Query getQuery(int id)
        {
            Query query = systemConfigurationDB.Queries.Where(param => param.QueryId == id).ToList()[0];
            return query;
        }

        public ServerSMTPParameter getServerSMTP(int id)
        {
            ServerSMTPParameter serverSMTP = systemConfigurationDB.ServerSMTPParameters.Where(param => param.ServerSMTPParametersId == id).ToList()[0];
            return serverSMTP;
        }

        public WebService getWebService(int id)
        {
            WebService webService = systemConfigurationDB.WebServices.Where(param => param.WebServiceId == id).ToList()[0];
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

            systemConfigurationDB.ActiveDirectoryParameters.Add(ad);
            systemConfigurationDB.SaveChanges();
        }

        public void saveServerSMPT(string nameServerSMTP, string port, string usernameSMTP, string passwordSMTP, string from, string subject, string body)
        {
            ServerSMTPParameter serverSmtp = new ServerSMTPParameter();
            serverSmtp.NameServerSMTP = nameServerSMTP;
            serverSmtp.Port = port;
            serverSmtp.UsernameSMTP = usernameSMTP;
            serverSmtp.PasswordSMTP = passwordSMTP;
            serverSmtp.EmailFrom = from;
            serverSmtp.Subject = subject;
            serverSmtp.Body = body;

            systemConfigurationDB.ServerSMTPParameters.Add(serverSmtp);
            systemConfigurationDB.SaveChanges();
        }

        public void saveQuery(string queryString, string queryName, string description, string integrationType)
        {
            Query query = new Query();
            query.Query1 = queryString;
            query.QueryName = queryName;
            query.Description = description;
            query.IntegrationTypeId = Convert.ToInt32(integrationType);

            systemConfigurationDB.Queries.Add(query);
            systemConfigurationDB.SaveChanges();
        }

        public void saveFlatFiles(string location)
        {
            FlatFilesParameter flatFile = new FlatFilesParameter();

            flatFile.Location = location;

            systemConfigurationDB.FlatFilesParameters.Add(flatFile);
            systemConfigurationDB.SaveChanges();
        }

        public void saveDatabase(string ip, string name, string username, string password, string engineId, string port = null, string instance = null)
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

            systemConfigurationDB.DatabaseParameters.Add(db);
            systemConfigurationDB.SaveChanges();
        }

        public void saveWebService(string endpoint, string username, string password)
        {
            WebService webService = new WebService();
            webService.Endpoint = endpoint;
            webService.Username = username;
            webService.Password = password;

            systemConfigurationDB.WebServices.Add(webService);
            systemConfigurationDB.SaveChanges();
        }

        // ================================================================================================================
        // Actualizar parametros del sistema.
        // ================================================================================================================
        public void updateActiveDirectory(int id, string domain, string path)
        {
            ActiveDirectoryParameter ad = systemConfigurationDB.ActiveDirectoryParameters.Where(param => param.ActiveDirectoryId == id).ToList()[0];
            ad.ADPath = domain;
            ad.ADDomain = path;

            systemConfigurationDB.SaveChanges();
        }

        public void updateDatabase(int id, string ip, string name, string username, string password, int engineId, string port = null, string instance = null)
        {
            DatabaseParameter db = systemConfigurationDB.DatabaseParameters.Where(param => param.DatabaseParametersId == id).ToList()[0];
            db.Ip = ip;
            db.Instance = instance;
            db.Name = name;
            db.Username = username;
            db.Password = password;
            db.Port = port;
            db.EngineId = engineId;

            systemConfigurationDB.SaveChanges();
        }

        public void updateFlatFile(int id, string location)
        {
            FlatFilesParameter flatFile = systemConfigurationDB.FlatFilesParameters.Where(param => param.FlatFileParameterId == id).ToList()[0];
            flatFile.Location = location;
            systemConfigurationDB.SaveChanges();
        }

        public void updateQuery(int id, string queryString, string queryName, string description, int integrationTypeId)
        {
            Query query = systemConfigurationDB.Queries.Where(param => param.QueryId == id).ToList()[0];
            query.Query1 = queryString;
            query.QueryName = queryName;
            query.Description = description;
            query.IntegrationTypeId = integrationTypeId;

            systemConfigurationDB.SaveChanges();
        }

        public void updateServerSMPT(int id, string nameServerSMTP, string port, string usernameSMTP, string passwordSMTP, string from, string subject, string body)
        {
            ServerSMTPParameter serverSmtp = systemConfigurationDB.ServerSMTPParameters.Where(param => param.ServerSMTPParametersId == id).ToList()[0];
            serverSmtp.NameServerSMTP = nameServerSMTP;
            serverSmtp.Port = port;
            serverSmtp.UsernameSMTP = usernameSMTP;
            serverSmtp.PasswordSMTP = passwordSMTP;
            serverSmtp.EmailFrom = from;
            serverSmtp.Subject = subject;
            serverSmtp.Body = body;

            systemConfigurationDB.SaveChanges();
        }

        public void updateWebService(int id, string endpoint, string username, string password)
        {
            WebService webService = systemConfigurationDB.WebServices.Where(param => param.WebServiceId == id).ToList()[0];
            webService.Endpoint = endpoint;
            webService.Username = username;
            webService.Password = password;

            systemConfigurationDB.SaveChanges();
        }

        // ================================================================================================================
        // Eliminar parametros del sistema.
        // ================================================================================================================
        public void deleteActiveDirectory(int activeDirectoryId)
        {
            ActiveDirectoryParameter activeDirectory = systemConfigurationDB.ActiveDirectoryParameters.Where(param => param.ActiveDirectoryId == activeDirectoryId).ToList()[0];

            systemConfigurationDB.ActiveDirectoryParameters.Remove(activeDirectory);
            systemConfigurationDB.SaveChanges();
        }

        public void deleteDataBase(int dataBaseId)
        {
            DatabaseParameter database = systemConfigurationDB.DatabaseParameters.Where(param => param.DatabaseParametersId == dataBaseId).ToList()[0];

            systemConfigurationDB.DatabaseParameters.Remove(database);
            systemConfigurationDB.SaveChanges();
        }

        public void deleteFlatFile(int flatFileIdId)
        {
            FlatFilesParameter flatFile = systemConfigurationDB.FlatFilesParameters.Where(param => param.FlatFileParameterId == flatFileIdId).ToList()[0];

            systemConfigurationDB.FlatFilesParameters.Remove(flatFile);
            systemConfigurationDB.SaveChanges();
        }

        public void deleteQuery(int queryId)
        {
            Query query = systemConfigurationDB.Queries.Where(param => param.QueryId == queryId).ToList()[0];

            systemConfigurationDB.Queries.Remove(query);
            systemConfigurationDB.SaveChanges();
        }

        public void deleteServerSMTP(int serverSMTPId)
        {
            ServerSMTPParameter serverSMTP = systemConfigurationDB.ServerSMTPParameters.Where(param => param.ServerSMTPParametersId == serverSMTPId).ToList()[0];

            systemConfigurationDB.ServerSMTPParameters.Remove(serverSMTP);
            systemConfigurationDB.SaveChanges();
        }

        public void deleteWebService(int webServiceId)
        {
            WebService webService = systemConfigurationDB.WebServices.Where(param => param.WebServiceId == webServiceId).ToList()[0];

            systemConfigurationDB.WebServices.Remove(webService);
            systemConfigurationDB.SaveChanges();
        }
    }
}
