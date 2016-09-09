﻿var ListFlatFilesController = function ($scope, $http) {
    $scope.typeMessage = 0;
    $scope.message = "";
    $scope.listFlatFiles = [];
    $scope.deleteFlatFile = deleteFlatFile;

    getListFlatFiles();

    function getListFlatFiles() {
        var config = {
            headers: {
                'Content-Type': 'application/x-www-form-urlencoded;charset=utf-8;'
            }
        }

        var data = $.param({});

        $http.post('Configuration/getListFlatFiles', data, config).success(function (resp) {
            if (resp.type !== 'danger') {
                $scope.listFlatFiles = resp;
            } else {
                $scope.message = resp.message;
                $scope.typeMessage = resp.type;
            }
        }).error(function (resp) {
            $scope.message = "Error: " + resp;
            $scope.typeMessage = "danger";
        });
    }

    function deleteFlatFile(FlatFileParametersId) {
        var config = {
            headers: {
                'Content-Type': 'application/x-www-form-urlencoded;charset=utf-8;'
            }
        }

        var data = $.param({});

        $http.delete('Configuration/deleteFlatFile?id=' + FlatFileParametersId, data, config).success(function (resp) {
            $scope.message = resp.message;
            $scope.typeMessage = resp.type;
            getListFlatFiles();
        }).error(function (resp) {
            $scope.message = "Error: " + resp;
            $scope.typeMessage = "danger";
        });
    }
}

ListFlatFilesController.$inject = ['$scope', '$http'];