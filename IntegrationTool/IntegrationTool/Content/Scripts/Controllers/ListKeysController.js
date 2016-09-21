﻿var ListKeysController = function ($scope, $http) {
    $scope.typeMessage = 0;
    $scope.message = "";
    $scope.listKeys = [];

    getListKeys();

    function getListKeys() {
        var config = {
            headers: {
                'Content-Type': 'application/x-www-form-urlencoded;charset=utf-8;'
            }
        }

        var data = $.param({});

        $http.get('Configuration/getListKeys', data, config).success(function (resp) {
            if (resp.type !== 'danger') {
                $scope.listKeys = resp;
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
ListKeysController.$inject = ['$scope', '$http'];