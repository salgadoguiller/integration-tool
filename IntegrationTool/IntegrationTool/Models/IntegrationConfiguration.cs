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
        // Almacenar integración en el sistema.
        // ================================================================================================================
        public void saveIntegrationManual(int userId,  int webServiceId, int databaseParametersId,
                                            int flatFileId, int flatFileParameterId, int integrationTypeId, int queryId,
                                            int integrationCategoryId, int operationWebServiceId, List<QueryParameter> queryParameters,
                                            string curlParameters = null)
        {
            Integration integration = new Integration();

            integration.IntegrationDate = DateTime.Now;
            integration.UserId = userId;
            integration.CurlParameters = curlParameters;
            integration.WebServiceId = webServiceId;
            integration.OperationWebServiceId = operationWebServiceId;
            integration.DatabaseParametersId = databaseParametersId;
            integration.FlatFileId = flatFileId;
            integration.FlatFileParameterId = flatFileParameterId;
            integration.IntegrationTypeId = integrationTypeId;
            integration.QueryId = queryId;
            integration.IntegrationCategoryId = integrationCategoryId;

            integration.QueryParameters = queryParameters;

            integrationConfigurationDB.Integrations.Add(integration);
            integrationConfigurationDB.SaveChanges();
        }

        public void saveIntegrationSchedule(int userId, int webServiceId, int databaseParametersId,
                                            int flatFileId, int flatFileParameterId, int integrationTypeId, int queryId,
                                            int integrationCategoryId, int operationWebServiceId, List<QueryParameter> queryParameters,
                                            DateTime executionStartDate, DateTime executionEndDate, int recurenceId, string emails = null,
                                            string curlParameters = null)
        {
            Integration integration = new Integration();

            integration.IntegrationDate = DateTime.Now;
            integration.UserId = userId;
            integration.CurlParameters = curlParameters;
            integration.WebServiceId = webServiceId;
            integration.OperationWebServiceId = operationWebServiceId;
            integration.DatabaseParametersId = databaseParametersId;
            integration.FlatFileId = flatFileId;
            integration.FlatFileParameterId = flatFileParameterId;
            integration.IntegrationTypeId = integrationTypeId;
            integration.QueryId = queryId;
            integration.IntegrationCategoryId = integrationCategoryId;

            integration.QueryParameters = queryParameters;

            Calendar calendar = new Calendar();
            calendar.Emails = emails;
            calendar.ExecutionEndDate = executionEndDate;
            calendar.ExecutionStartDate = executionStartDate;
            calendar.NextExecutionDate = executionStartDate;
            calendar.RecurrenceId = recurenceId;

            integration.Calendars.Add(calendar);

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

        public List<Integration> getScheduleIntegrations()
        {
            List<Integration> integrations = integrationConfigurationDB.Integrations.Where(param => param.IntegrationCategoryId == 2).ToList();
            return integrations;
        }

        public List<Integration> getManualIntegrations()
        {
            List<Integration> integrations = integrationConfigurationDB.Integrations.Where(param => param.IntegrationCategoryId == 1).ToList();
            return integrations;
        }
    }
}
