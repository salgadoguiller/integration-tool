﻿var ConfigurationHeadersController = function ($scope, $http) {
    $scope.typeMessage = 0;
    $scope.message = "";
    $scope.request = {};
    $scope.sendRequest = sendRequest;
    $scope.QueriesType = [];

    getQueriesType();

    function getQueriesType() {
        var config = {
            headers: {
                'Content-Type': 'application/x-www-form-urlencoded;charset=utf-8;'
            }
        }

        var data = $.param({});

        $http.post('Configuration/getTypeQueries', data, config).success(function (resp) {
            $scope.QueriesType = resp;
        }).error(function (resp) {
            $scope.message = "Error: " + resp;
            $scope.typeMessage = "danger";
        });
    }

    function sendRequest(req, form) {
        if (!form.$valid) {
            $scope.message = "Error: Invalid form, please try again.";
            $scope.typeMessage = "danger";
            return false;
        }

        var config = {
            headers: {
                'Content-Type': 'application/x-www-form-urlencoded;charset=utf-8;'
            }
        }

        var data = $.param(req);

        $http.post('Configuration/saveHeaders', data, config).success(function (resp) {
            $scope.message = "Success: " + resp.message;
            $scope.typeMessage = "success";
            $scope.request = {};
            form.$setPristine();
            form.$setUntouched();
        }).error(function (resp) {
            $scope.message = "Error: " + resp;
            $scope.typeMessage = "danger";
        });
    }
}

ConfigurationHeadersController.$inject = ['$scope', '$http'];