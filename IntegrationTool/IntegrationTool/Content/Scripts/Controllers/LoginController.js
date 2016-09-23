﻿var LoginController = function ($scope, $http, $state, Authentication) {
    $scope.typeMessage = 0;
    $scope.message = "";
    $scope.request = {};
    $scope.sendRequest = sendRequest;
    var authentication = Authentication;

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

        $http.post('Account/login', data, config).success(function (resp) {
            if (resp.type !== 'danger') {
                authentication.user = resp;
                $state.go($state.previous.state.name || 'main.integrations.calendar', $state.previous.params);
            } else {
                $scope.message = resp.message;
                $scope.typeMessage = resp.type;
                $scope.request.Password = '';
            }
        }).error(function (resp) {
            $scope.message = "Error: " + resp;
            $scope.typeMessage = "danger";
        });
    }
}

LoginController.$inject = ['$scope', '$http', '$state', 'Authentication'];