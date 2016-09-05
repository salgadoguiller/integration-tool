﻿var ConfigurationDataBasesController = function ($scope, $http) {
    $scope.message = 0;
    $scope.response = "";
    $scope.request = {};
    $scope.sendRequest = sendRequest;
    $scope.dataBaseEngines = [];

    getDataBaseEngines();

    function getDataBaseEngines() {
        var config = {
            headers: {
                'Content-Type': 'application/x-www-form-urlencoded;charset=utf-8;'
            }
        }

        var data = $.param({});

        $http.post('Configuration/getDataBaseEngines', data, config).success(function (resp) {
            $scope.dataBaseEngines = resp;
        }).error(function (resp) {
            $scope.response = resp;
            $scope.message = 2;
        });
    }

    function sendRequest(req) {
        var config = {
            headers: {
                'Content-Type': 'application/x-www-form-urlencoded;charset=utf-8;'
            }
        }

        var data = $.param(req);

        $http.post('Configuration/saveDataBase', data, config).success(function (resp) {
            $scope.response = resp.message;
            $scope.message = 1;
            $scope.request = {};
        }).error(function (resp) {
            $scope.response = resp;
            $scope.message = 2;
        });
    }
}

ConfigurationDataBasesController.$inject = ['$scope', '$http'];