using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IntegrationTool.Models
{
    public class IntegrationConfiguration
    {
        private IntegrationToolEntities integrationConfigurationDB;

        public IntegrationConfiguration()
        {
            integrationConfigurationDB = new IntegrationToolEntities();
        }


        // ================================================================================================================
        // Almacenar integracion en el sistema.
        // ================================================================================================================
        public void saveIntegration(int userId,  int webServiceId, int databaseParametersId, int serverSMTPParametersId, int flatFileId, int flatFileParameterId, int integrationTypeId, int queryId, List<QueryParameter> queryParameters) 
        {
            Integration integration = new Integration();

            integration.IntegrationDate = DateTime.Now;
            integration.UserId = userId;
            integration.WebServiceId = webServiceId;
            integration.DatabaseParametersId =  databaseParametersId;
            integration.ServerSMTPParametersId = serverSMTPParametersId;
            integration.FlatFileId = flatFileId;
            integration.FlatFileParameterId = flatFileParameterId;
            integration.IntegrationTypeId = integrationTypeId;
            integration.QueryId = queryId;

            integration.QueryParameters = queryParameters;

            integrationConfigurationDB.Integrations.Add(integration);
            integrationConfigurationDB.SaveChanges();
        }
    }
}