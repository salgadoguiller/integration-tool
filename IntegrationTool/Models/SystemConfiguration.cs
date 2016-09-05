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

        public List<ActiveDirectoryParameter> getActiveDirectories()
        {
            List<ActiveDirectoryParameter> activeDirectories = (from ad in SystemConfigurationDB.ActiveDirectoryParameters
                                                select ad).ToList();
       
            return activeDirectories;
        }

        public void saveActiveDirectory(string domain, string path)
        {
            ActiveDirectoryParameter ad = new ActiveDirectoryParameter();
            ad.ADPath = domain;
            ad.ADDomain = path;

            SystemConfigurationDB.ActiveDirectoryParameters.Add(ad);
            SystemConfigurationDB.SaveChanges();
        }

        public List<ServerSMTPParameter> getServersSMTP()
        {
            List<ServerSMTPParameter> serverSmtp = (from server in SystemConfigurationDB.ServerSMTPParameters
                                                                select server).ToList();
            return serverSmtp;
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

        public List<FlatFileParameter> getFlatFiles()
        {
            List<FlatFileParameter> flatFiles = (from ff in SystemConfigurationDB.FlatFileParameters
                                                    select ff).ToList();
            return flatFiles;
        }

        public void saveFlatFiles(string location)
        {           
            FlatFileParameter flatFile = new FlatFileParameter();

            flatFile.Location = location;
           
            SystemConfigurationDB.FlatFileParameters.Add(flatFile);
            SystemConfigurationDB.SaveChanges();
        }

        public List<DatabaseParameter> getDatabases()
        {
            List<DatabaseParameter> databases = (from db in SystemConfigurationDB.DatabaseParameters
                                                                select db).ToList();
            return databases;
        }

        public void saveDatabase(string ip, string instance, string name, string username, string password, string engine, string port)
        {
            DatabaseParameter db = new DatabaseParameter();
            db.Ip = ip;
            db.Instance = instance;
            db.Name = name;
            db.Username = username;
            db.Password = password;
            //db.Engine = engine;
            db.Port = port;

            SystemConfigurationDB.DatabaseParameters.Add(db);
            SystemConfigurationDB.SaveChanges();
        }

        public List<WebService> getWebServices()
        {
            List<WebService> webServices = (from ws in SystemConfigurationDB.WebServices
                                                 select ws).ToList();
            return webServices;
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
    }
}