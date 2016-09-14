﻿using System;
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
        // Almacenar integración en el sistema.
        // ================================================================================================================
        public void saveIntegration(int userId,  int webServiceId, int databaseParametersId, int flatFileId, int flatFileParameterId, int integrationTypeId, int queryId, List<QueryParameter> queryParameters) 
        {
            Integration integration = new Integration();

            integration.IntegrationDate = DateTime.Now;
            integration.UserId = userId;
            integration.WebServiceId = webServiceId;
            integration.DatabaseParametersId =  databaseParametersId;
            integration.FlatFileId = flatFileId;
            integration.FlatFileParameterId = flatFileParameterId;
            integration.IntegrationTypeId = integrationTypeId;
            integration.QueryId = queryId;

            integration.QueryParameters = queryParameters;

            integrationConfigurationDB.Integrations.Add(integration);
            integrationConfigurationDB.SaveChanges();
        }


        // ================================================================================================================
        // Obtener información para realizar una integración
        // ================================================================================================================
        public List<IntegrationCategory> getIntegrationCategories()
        {
            List<IntegrationCategory> integrationCategories = integrationConfigurationDB.IntegrationCategories.ToList();
            return integrationCategories;
        }

        public List<Query> getQueriesByIntegrationType(int id)
        {
            List<Query> queries = integrationConfigurationDB.Queries.Where(param => param.IntegrationTypeId == id).ToList();
            return queries;
        }

        public List<OperationsWebService> getOperationsWebServices()
        {
            List<OperationsWebService> operations = integrationConfigurationDB.OperationsWebServices.ToList();
            return operations;
        }

        public List<Recurrence> getRecurrences()
        {
            List<Recurrence> recurrences = integrationConfigurationDB.Recurrences.ToList();
            return recurrences;
        }
    }
}