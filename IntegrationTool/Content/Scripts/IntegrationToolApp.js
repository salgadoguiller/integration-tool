var IntegrationToolApp = angular.module('IntegrationToolApp', ['ngRoute', 'ngMessages', 'ng-sweet-alert']);

IntegrationToolApp.controller('ConfigurationActiveDirectoryController', ConfigurationActiveDirectoryController);
IntegrationToolApp.controller('ConfigurationServerSMTPController', ConfigurationServerSMTPController);
IntegrationToolApp.controller('ConfigurationDataBasesController', ConfigurationDataBasesController);
IntegrationToolApp.controller('ConfigurationWebServicesController', ConfigurationWebServicesController);
IntegrationToolApp.controller('ConfigurationFlatFilesController', ConfigurationFlatFilesController);
IntegrationToolApp.controller('ConfigurationQueriesController', ConfigurationQueriesController);
IntegrationToolApp.controller('ConfigurationHeadersController', ConfigurationHeadersController);
IntegrationToolApp.controller('ConfigurationActiveDirectoryMainController', ConfigurationActiveDirectoryMainController);
IntegrationToolApp.controller('AlertController', AlertController);

IntegrationToolApp.directive('feedback', feedBackMessagesDirective);

var configFunction = function ($routeProvider) {
    $routeProvider
        .when('/Main/index', {
            templateUrl: '/Main/index'
        })
        .when('/Configuration/activedirectorymain', {
            templateUrl: '/Configuration/activedirectorymain',
            controller: 'ConfigurationActiveDirectoryMainController'
        })
        .when('/Configuration/activedirectory', {
            templateUrl: '/Configuration/activedirectory',
            controller: 'ConfigurationActiveDirectoryController'
        })
        .when('/Configuration/serversmtp', {
            templateUrl: '/Configuration/serversmtp',
            controller: 'ConfigurationServerSMTPController'
        })
        .when('/Configuration/databases', {
            templateUrl: '/Configuration/databases',
            controller: 'ConfigurationDataBasesController'
        })
        .when('/Configuration/webservices', {
            templateUrl: '/Configuration/webservices',
            controller: 'ConfigurationWebServicesController'
        })
        .when('/Configuration/flatfiles', {
            templateUrl: '/Configuration/flatfiles',
            controller: 'ConfigurationFlatFilesController'
        })
        .when('/Configuration/queries', {
            templateUrl: '/Configuration/queries',
            controller: 'ConfigurationQueriesController'
        })
        .when('/Configuration/headers', {
            templateUrl: '/Configuration/headers',
            controller: 'ConfigurationHeadersController'
        });
}
configFunction.$inject = ['$routeProvider'];

IntegrationToolApp.config(configFunction);