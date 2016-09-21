var IntegrationToolApp = angular.module('IntegrationToolApp', ['ngRoute', 'ngMessages', 'ng-sweet-alert', 'ui.calendar', 'ui.bootstrap']);

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

IntegrationToolApp.controller('AlertController', AlertController);
IntegrationToolApp.directive('feedback', feedBackMessagesDirective);

var configFunction = function ($routeProvider) {
    $routeProvider
        .when('/Main/index', {
            templateUrl: '/Main/index'
        })
        .when('/Configuration/listActiveDirectories', {
            templateUrl: '/Configuration/listActiveDirectories',
            controller: 'ListActiveDirectoriesController'
        })
        .when('/Configuration/listDatabases', {
            templateUrl: '/Configuration/listDatabases',
            controller: 'ListDatabasesController'
        })
        .when('/Configuration/listFlatFiles', {
            templateUrl: '/Configuration/listFlatFiles',
            controller: 'ListFlatFilesController'
        })
        .when('/Configuration/listQueries', {
            templateUrl: '/Configuration/listQueries',
            controller: 'ListQueriesController'
        })
        .when('/Configuration/listServerSMTP', {
            templateUrl: '/Configuration/listServerSMTP',
            controller: 'ListServerSMTPController'
        })
        .when('/Configuration/listWebServices', {
            templateUrl: '/Configuration/listWebServices',
            controller: 'ListWebServicesController'
        })
        .when('/Configuration/listKeys', {
            templateUrl: '/Configuration/listKeys',
            controller: 'ListKeysController'
        })
        .when('/Configuration/formActiveDirectory/:id', {
            templateUrl: '/Configuration/formActiveDirectory',
            controller: 'FormActiveDirectoryController'
        })
        .when('/Configuration/formDatabase/:id', {
            templateUrl: '/Configuration/formDatabase',
            controller: 'FormDataBaseController'
        })
        .when('/Configuration/formFlatFile/:id', {
            templateUrl: '/Configuration/formFlatFile',
            controller: 'FormFlatFileController'
        })
        .when('/Configuration/formQuery/:id', {
            templateUrl: '/Configuration/formQuery',
            controller: 'FormQueryController'
        })
        .when('/Configuration/formServerSMTP/:id', {
            templateUrl: '/Configuration/formServerSMTP',
            controller: 'FormServerSMTPController'
        })
        .when('/Configuration/formWebService/:id', {
            templateUrl: '/Configuration/formWebService',
            controller: 'FormWebServiceController'
        })
        .when('/Integration/configurationManual/:id', {
            templateUrl: '/Integration/configurationManual',
            controller: 'ConfigIntegrationManualController'
        })
        .when('/Integration/configurationScheduled/:id', {
            templateUrl: '/Integration/configurationScheduled',
            controller: 'ConfigIntegrationScheduledController'
        })
        .when('/Integration/manual', {
            templateUrl: '/Integration/manual',
            controller: 'ManualIntegrationController'
        })
        .when('/Integration/calendar', {
            templateUrl: '/Integration/calendar',
            controller: 'SheduleIntegrationsController'
        });
}
configFunction.$inject = ['$routeProvider'];

IntegrationToolApp.config(configFunction);