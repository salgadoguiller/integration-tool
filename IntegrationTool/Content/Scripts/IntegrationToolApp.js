var IntegrationToolApp = angular.module('IntegrationToolApp', ['ngRoute']);

IntegrationToolApp.controller('MainController', MainController);

var configFunction = function ($routeProvider) {
    $routeProvider.
        when('/Configuration/activedirectory', {
            templateUrl: '/Configuration/activedirectory'
        })
        .when('/Configuration/serversmtp', {
            templateUrl: '/Configuration/serversmtp'
        })
        .when('/Configuration/database', {
            templateUrl: '/Configuration/database'
        });
}
configFunction.$inject = ['$routeProvider'];

IntegrationToolApp.config(configFunction);