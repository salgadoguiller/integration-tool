﻿var ListHeadersController = function ($scope, $http) {
    $scope.typeMessage = 0;
    $scope.message = "";
    $scope.listHeaders = [];

    getListHeaders();

    function getListHeaders() {
        var config = {
            headers: {
                'Content-Type': 'application/x-www-form-urlencoded;charset=utf-8;'
            }
        }

        var data = $.param({});

        $http.post('Configuration/getListHeaders', data, config).success(function (resp) {
            if (resp.type !== 'danger') {
                $scope.listHeaders = resp;
            } else {
                $scope.message = resp.message;
                $scope.typeMessage = resp.type;
            }
        }).error(function (resp) {
            $scope.message = "Error: " + resp;
            $scope.typeMessage = "danger";
        });
    }
}
ListHeadersController.$inject = ['$scope', '$http'];