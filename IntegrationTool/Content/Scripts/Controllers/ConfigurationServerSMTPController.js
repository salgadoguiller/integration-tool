﻿var ConfigurationServerSMTPController = function ($scope, $http)
{
    $scope.message = 0;
    $scope.response = "";
    $scope.request = {};
    $scope.sendRequest = sendRequest;

    function sendRequest(req) {
        var config = {
            headers: {
                'Content-Type': 'application/x-www-form-urlencoded;charset=utf-8;'
            }
        }

        var data = $.param(req);

        $http.post('Configuration/saveServerSmtp', data, config).success(function (resp) {
            $scope.response = resp.message;
            $scope.message = 1;
            $scope.request =
            {
                'NameServerSMTP': '',
                'Port': '',
                'UsernameSMTP': '',
                'PasswordSMTP':''
            }
        }).error(function (resp) {
            $scope.response = resp;
            $scope.message = 2;
        });
    }

}

ConfigurationServerSMTPController.$inject = ['$scope', '$http'];

