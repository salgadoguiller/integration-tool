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

        public void saveServersSMPT(string NameServerSMTP, string Port, string UsernameSMTP, string PasswordSMTP)
        {           
            ServerSMTPParameter serverSmtp = new ServerSMTPParameter();
            serverSmtp.NameServerSMTP = NameServerSMTP;
            serverSmtp.Port = Port;
            serverSmtp.UsernameSMTP = UsernameSMTP;
            serverSmtp.PasswordSMTP = PasswordSMTP;

            SystemConfigurationDB.ServerSMTPParameters.Add(serverSmtp);
            SystemConfigurationDB.SaveChanges();      
        }

        public List<ServerSMTPParameter> getFlatFiles()
        {
            List<ServerSMTPParameter> serverSmtp = (from server in SystemConfigurationDB.ServerSMTPParameters
                                                    select server).ToList();
            return serverSmtp;
        }

        public void saveFlatFiles(string location)
        {           
            FlatFileParameter flatFile = new FlatFileParameter();

            flatFile.Location = location;
           
            SystemConfigurationDB.FlatFileParameters.Add(flatFile);
            SystemConfigurationDB.SaveChanges();
        }   
    }
}