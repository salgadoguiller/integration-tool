var IntegrationToolApp = angular.module('IntegrationToolApp', ['ngRoute', 'ngMessages', 'ng-sweet-alert', 'ui.calendar', 'ui.bootstrap', 'ui.router']);

IntegrationToolApp.controller('FormActiveDirectoryController', FormActiveDirectoryController);
IntegrationToolApp.controller('FormDataBaseController', FormDataBaseController);
IntegrationToolApp.controller('FormFlatFileController', FormFlatFileController);
IntegrationToolApp.controller('FormQueryController', FormQueryController);
IntegrationToolApp.controller('FormServerSMTPController', FormServerSMTPController);
IntegrationToolApp.controller('FormWebServiceController', FormWebServiceController);

IntegrationToolApp.controller('ListActiveDirectoriesController', ListActiveDirectoriesController);
IntegrationToolApp.controller('ListDatabasesController', ListDatabasesController);
IntegrationToolApp.controller('ListFlatFilesController', ListFlatFilesController);
IntegrationToolApp.controller('ListQueriesController', ListQueriesController);
IntegrationToolApp.controller('ListServerSMTPController', ListServerSMTPController);
IntegrationToolApp.controller('ListWebServicesController', ListWebServicesController);
IntegrationToolApp.controller('ListKeysController', ListKeysController);

IntegrationToolApp.controller('ConfigIntegrationManualController', ConfigIntegrationManualController);
IntegrationToolApp.controller('ConfigIntegrationScheduledController', ConfigIntegrationScheduledController);
IntegrationToolApp.controller('ManualIntegrationController', ManualIntegrationController);
IntegrationToolApp.controller('SheduleIntegrationsController', SheduleIntegrationsController);

IntegrationToolApp.controller('ListIntegrationLogsController', ListIntegrationLogsController);
IntegrationToolApp.controller('ListSystemLogsController', ListSystemLogsController);

IntegrationToolApp.controller('LoginController', LoginController);

IntegrationToolApp.controller('AlertController', AlertController);
IntegrationToolApp.directive('feedback', feedBackMessagesDirective);

var configFunction = function ($routeProvider, $stateProvider, $urlRouterProvider) {
    $urlRouterProvider.otherwise('/main/integrations/calendar');
    // Login
    $stateProvider
    .state('login', {
        url: '/account/login',
        templateUrl: '/Account/login',
        controller: 'LoginController'
    })
    // Rutas para usuarios logeados.
    .state('main', {
        abstract: true,
        url: '/main',
        templateUrl: 'Main/layout' 
    })
    // Pestaña de configuración
    .state('main.configuration', {
        abstract: true,
        url: '/configuration',
        template: '<div ui-view></div>'
    })
    .state('main.configuration.listActiveDirectories', {
        url: '/listActiveDirectories',
        templateUrl: '/Configuration/listActiveDirectories',
        controller: 'ListActiveDirectoriesController'
    })
    .state('main.configuration.listDatabases', {
        url: '/listDatabases',
        templateUrl: '/Configuration/listDatabases',
        controller: 'ListDatabasesController'
    })
    .state('main.configuration.listFlatFiles', {
        url: '/listFlatFiles',
        templateUrl: '/Configuration/listFlatFiles',
        controller: 'ListFlatFilesController'
    })
    .state('main.configuration.listQueries', {
        url: '/listQueries',
        templateUrl: '/Configuration/listQueries',
        controller: 'ListQueriesController'
    })
    .state('main.configuration.listServerSMTP', {
        url: '/listServerSMTP',
        templateUrl: '/Configuration/listServerSMTP',
        controller: 'ListServerSMTPController'
    })
    .state('main.configuration.listWebServices', {
        url: '/listWebServices',
        templateUrl: '/Configuration/listWebServices',
        controller: 'ListWebServicesController'
    })
    .state('main.configuration.listKeys', {
        url: '/listKeys',
        templateUrl: '/Configuration/listKeys',
        controller: 'ListKeysController'
    })
    .state('main.configuration.formActiveDirectory', {
        url: '/formActiveDirectory/:id',
        templateUrl: '/Configuration/formActiveDirectory',
        controller: 'FormActiveDirectoryController'
    })
    .state('main.configuration.formDatabase', {
        url: '/formDatabase/:id',
        templateUrl: '/Configuration/formDatabase',
        controller: 'FormDataBaseController'
    })
    .state('main.configuration.formFlatFile', {
        url: '/formFlatFile/:id',
        templateUrl: '/Configuration/formFlatFile',
        controller: 'FormFlatFileController'
    })
    .state('main.configuration.formQuery', {
        url: '/formQuery/:id',
        templateUrl: '/Configuration/formQuery',
        controller: 'FormQueryController'
    })
    .state('main.configuration.formServerSMTP', {
        url: '/formServerSMTP/:id',
        templateUrl: '/Configuration/formServerSMTP',
        controller: 'FormServerSMTPController'
    })
    .state('main.configuration.formWebService', {
        url: '/formWebService/:id',
        templateUrl: '/Configuration/formWebService',
        controller: 'FormWebServiceController'
    })
    // Pestaña de integraciones
    .state('main.integrations', {
        abstract: true,
        url: '/integrations',
        template: '<div ui-view></div>'
    })
    .state('main.integrations.configurationManual', {
        url: '/configurationManual/:id',
        templateUrl: '/Integration/configurationManual',
        controller: 'ConfigIntegrationManualController'
    })
    .state('main.integrations.configurationScheduled', {
        url: '/configurationScheduled/:id',
        templateUrl: '/Integration/configurationScheduled',
        controller: 'ConfigIntegrationScheduledController'
    })
    .state('main.integrations.manual', {
        url: '/manual',
        templateUrl: '/Integration/manual',
        controller: 'ManualIntegrationController'
    })
    .state('main.integrations.calendar', {
        url: '/calendar',
        templateUrl: '/Integration/calendar',
        controller: 'SheduleIntegrationsController'
    })
    // Pestaña de logs
    .state('main.logs', {
        abstract: true,
        url: '/logs',
        template: '<div ui-view></div>'
    })
    .state('main.logs.listSystemLogs', {
        url: '/listSystemLogs',
        templateUrl: '/Logs/listSystemLogs',
        controller: 'ListSystemLogsController'
    })
    .state('main.logs.listIntegrationLogs', {
        url: '/listIntegrationLogs',
        templateUrl: '/Logs/listIntegrationLogs',
        controller: 'ListIntegrationLogsController'
    });

}
configFunction.$inject = ['$routeProvider', '$stateProvider', '$urlRouterProvider'];

IntegrationToolApp.config(configFunction);