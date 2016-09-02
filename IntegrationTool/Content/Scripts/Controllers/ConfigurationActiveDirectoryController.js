﻿var ConfigurationActiveDirectoryController = function ($scope, $http) {
    $scope.message = 0;
    $scope.response = "";
    $scope.request = {};
    $scope.sendRequest = sendRequest;

    function sendRequest(req)
    {
        var config = {
            headers: {
                'Content-Type': 'application/x-www-form-urlencoded;charset=utf-8;'
            }
        }

        var data = $.param(req);

        $http.post('Configuration/saveActiveDirectory', data, config).success(function (resp) {
            $scope.response = resp.ADDomain + resp.ADPath;
            $scope.message = 1;
        }).error(function (resp) {
            $scope.response = resp;
            $scope.message = 2;
        });
    }

}

ConfigurationActiveDirectoryController.$inject = ['$scope', '$http'];