﻿var ListServerSMTPController = function ($scope, $http, $location) {
    $scope.typeMessage = 0;
    $scope.message = "";
    $scope.listServersSMTP = [];
    $scope.deleteServerSMTP = deleteServerSMTP;
    $scope.editServerSMTP = editServerSMTP;

    getListServersSMTP();

    function getListServersSMTP() {
        var config = {
            headers: {
                'Content-Type': 'application/x-www-form-urlencoded;charset=utf-8;'
            }
        }

        var data = $.param({});

        $http.get('Configuration/getListServersSMTP', data, config).success(function (resp) {
            if (resp.type !== 'danger') {
                $scope.listServersSMTP = resp;
            } else {
                $scope.message = resp.message;
                $scope.typeMessage = resp.type;
            }
        }).error(function (resp) {
            $scope.message = "Error: " + resp;
            $scope.typeMessage = "danger";
        });
    }

    function deleteServerSMTP(ServerSMTPParametersId) {
        var config = {
            headers: {
                'Content-Type': 'application/x-www-form-urlencoded;charset=utf-8;'
            }
        }

        var data = $.param({});

        $http.delete('Configuration/deleteServerSMTP?id=' + ServerSMTPParametersId, data, config).success(function (resp) {
            $scope.message = resp.message;
            $scope.typeMessage = resp.type;
            getListServersSMTP();
        }).error(function (resp) {
            $scope.message = "Error: " + resp;
            $scope.typeMessage = "danger";
        });
    }

    function editServerSMTP(id) {
        $location.url('/Configuration/formServerSMTP/' + id);
    }
}

ListServerSMTPController.$inject = ['$scope', '$http', '$location'];