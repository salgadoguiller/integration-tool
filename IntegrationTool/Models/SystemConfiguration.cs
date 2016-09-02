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
    }
}