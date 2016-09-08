var IntegrationToolApp = angular.module('IntegrationToolApp', ['ngRoute', 'ngMessages', 'ng-sweet-alert']);

IntegrationToolApp.controller('ConfigurationActiveDirectoryController', ConfigurationActiveDirectoryController);
IntegrationToolApp.controller('ConfigurationDataBasesController', ConfigurationDataBasesController);
IntegrationToolApp.controller('ConfigurationFlatFilesController', ConfigurationFlatFilesController);
IntegrationToolApp.controller('ConfigurationHeadersController', ConfigurationHeadersController);
IntegrationToolApp.controller('ConfigurationQueriesController', ConfigurationQueriesController);
IntegrationToolApp.controller('ConfigurationServerSMTPController', ConfigurationServerSMTPController);
IntegrationToolApp.controller('ConfigurationWebServicesController', ConfigurationWebServicesController);

IntegrationToolApp.controller('ListActiveDirectoriesController', ListActiveDirectoriesController);
IntegrationToolApp.controller('ListDatabasesController', ListDatabasesController);
IntegrationToolApp.controller('ListFlatFilesController', ListFlatFilesController);
IntegrationToolApp.controller('ListHeadersController', ListHeadersController);
IntegrationToolApp.controller('ListQueriesController', ListQueriesController);
IntegrationToolApp.controller('ListServerSMTPController', ListServerSMTPController);
IntegrationToolApp.controller('ListWebServicesController', ListWebServicesController);

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
        .when('/Configuration/listHeaders', {
            templateUrl: '/Configuration/listHeaders',
            controller: 'ListHeadersController'
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
        .when('/Configuration/formActiveDirectory', {
            templateUrl: '/Configuration/formActiveDirectory',
            controller: 'ConfigurationActiveDirectoryController'
        })
        .when('/Configuration/formDatabase', {
            templateUrl: '/Configuration/formDatabase',
            controller: 'ConfigurationDataBasesController'
        })
        .when('/Configuration/formFlatFile', {
            templateUrl: '/Configuration/formFlatFile',
            controller: 'ConfigurationFlatFilesController'
        })
        .when('/Configuration/formHeaders', {
            templateUrl: '/Configuration/formHeaders',
            controller: 'ConfigurationHeadersController'
        })
        .when('/Configuration/formQuery', {
            templateUrl: '/Configuration/formQuery',
            controller: 'ConfigurationQueriesController'
        })
        .when('/Configuration/formServerSMTP', {
            templateUrl: '/Configuration/formServerSMTP',
            controller: 'ConfigurationServerSMTPController'
        })
        .when('/Configuration/formWebService', {
            templateUrl: '/Configuration/formWebService',
            controller: 'ConfigurationWebServicesController'
        });
}
configFunction.$inject = ['$routeProvider'];

IntegrationToolApp.config(configFunction);