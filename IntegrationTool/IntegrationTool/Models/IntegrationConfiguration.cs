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
        public void saveIntegrationManual(int userId,  int webServiceId, int databaseParametersId, int flatFileId, 
                                            int flatFileParameterId, int integrationTypeId, int queryId, 
                                            int integrationCategoryId, List<QueryParameter> queryParameters) 
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
            integration.IntegrationCategoryId = integrationCategoryId;

            integration.QueryParameters = queryParameters;

            integrationConfigurationDB.Integrations.Add(integration);
            integrationConfigurationDB.SaveChanges();
        }

        public void saveIntegrationSchedule(int userId, int webServiceId, int databaseParametersId, int flatFileId, 
                                            int flatFileParameterId, int integrationTypeId, int queryId, 
                                            int integrationCategoryId, List<QueryParameter> queryParameters,
                                            DateTime executionStartDate, DateTime executionEndDate, string emails, 
                                            int recurenceId)
        {
            Integration integration = new Integration();

            integration.IntegrationDate = DateTime.Now;
            integration.UserId = userId;
            integration.WebServiceId = webServiceId;
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

        public List<IntegrationSchedule> getIntegrationShedule()
        {
            List<Integration> integrations = integrationConfigurationDB.Integrations.Where(param => param.IntegrationCategoryId == 2).ToList();

            List<IntegrationSchedule> integrationsSchedule = new List<IntegrationSchedule>();

            foreach(Integration i in integrations)
            {
                IntegrationSchedule integrationSchedule = new IntegrationSchedule();
                integrationSchedule.IntegrationId = i.IntegrationId;
                integrationSchedule.Name = i.IntegrationsType.Name;
                integrationSchedule.NextExecutionDate = Convert.ToDateTime(i.Calendars.ElementAt(0).NextExecutionDate);

                integrationsSchedule.Add(integrationSchedule);
            }

            return integrationsSchedule;
        }
    }
}