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
    }
}