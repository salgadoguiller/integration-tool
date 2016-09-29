using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IntegrationTool.Models
{
    public class LogsConfiguration
    {
        private IntegrationToolEntities LogsConfigurationDB;

        public LogsConfiguration()
        {
            LogsConfigurationDB = new IntegrationToolEntities();
        }

        // ================================================================================================================
        // Obtener parametros del sistema.
        // ================================================================================================================      

        public List<SystemLog> getSystemLogs()
        {
            List<SystemLog> systemLogs = (from sl in LogsConfigurationDB.SystemLogs
                        select sl).ToList();
            return systemLogs;
        }

        public List<IntegrationLog> getIntegrationLogs()
        {
            List<IntegrationLog> IntegrationLogs = (from il in LogsConfigurationDB.IntegrationLogs
                                          select il).ToList();
            return IntegrationLogs;
        }

        public string getWebServiceUser(int integrationId)
        {
            return LogsConfigurationDB.Integrations.Where(param => param.IntegrationId == integrationId).ToList()[0].WebService.Username;
        }

        public string getWebServicePassword(int integrationId)
        {
            return LogsConfigurationDB.Integrations.Where(param => param.IntegrationId == integrationId).ToList()[0].WebService.Password;
        }

        public string getWebServiceEndPoint(int integrationId)
        {
            return LogsConfigurationDB.Integrations.Where(param => param.IntegrationId == integrationId).ToList()[0].WebService.Endpoint;
        }

        public string getPath(int integrationId)
        {
            return LogsConfigurationDB.Integrations.Where(param => param.IntegrationId == integrationId).ToList()[0].FlatFilesParameter.Location;
        }
    }
}