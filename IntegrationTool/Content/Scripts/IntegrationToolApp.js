var IntegrationToolApp = angular.module('IntegrationToolApp', ['ngRoute']);

IntegrationToolApp.controller('MainController', MainController);
IntegrationToolApp.controller('ConfigurationActiveDirectoryController', ConfigurationActiveDirectoryController);

var configFunction = function ($routeProvider) {
    $routeProvider
        .when('/Main/index', {
            templateUrl: '/Main/index'
        })
        .when('/Configuration/activedirectory', {
            templateUrl: '/Configuration/activedirectory',
            controller: 'ConfigurationActiveDirectoryController'
        })
        .when('/Configuration/serversmtp', {
            templateUrl: '/Configuration/serversmtp'
        })
        .when('/Configuration/databases', {
            templateUrl: '/Configuration/databases'
        })
        .when('/Configuration/webservices', {
            templateUrl: '/Configuration/webservices'
        })
        .when('/Configuration/flatfiles', {
            templateUrl: '/Configuration/flatfiles'
        })
        .when('/Configuration/queries', {
            templateUrl: '/Configuration/queries'
        })
        .when('/Configuration/headers', {
            templateUrl: '/Configuration/headers'
        });
}
configFunction.$inject = ['$routeProvider'];

IntegrationToolApp.config(configFunction);