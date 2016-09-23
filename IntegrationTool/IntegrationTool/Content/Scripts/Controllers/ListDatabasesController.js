﻿var ListDatabasesController = function ($scope, $http, $location, $state) {
    $scope.typeMessage = 0;
    $scope.message = "";
    $scope.listDatabases = [];
    $scope.deleteDatabase = deleteDatabase;
    $scope.editDatabase = editDatabase;

    getListDatabases();

    function getListDatabases() {
        var config = {
            headers: {
                'Content-Type': 'application/x-www-form-urlencoded;charset=utf-8;'
            }
        }

        var data = $.param({});

        $http.get('Configuration/getListDatabases', data, config).success(function (resp) {
            if (resp.type !== 'danger') {
                $scope.listDatabases = resp;
            } else {
                $scope.message = resp.message;
                $scope.typeMessage = resp.type;
            }
        }).error(function (resp) {
            $state.transitionTo('main.errors.internalServerError');
        });
    }

    function deleteDatabase(DatabaseParametersId) {
        var config = {
            headers: {
                'Content-Type': 'application/x-www-form-urlencoded;charset=utf-8;'
            }
        }

        var data = $.param({});

        $http.delete('Configuration/deleteDataBase?id=' + DatabaseParametersId, data, config).success(function (resp) {
            $scope.message = resp.message;
            $scope.typeMessage = resp.type;
            getListDatabases();
        }).error(function (resp) {
            $state.transitionTo('main.errors.internalServerError');
        });
    }

    function editDatabase(id) {
        $location.url('/main/configuration/formDatabase/' + id);
    }
}
ListDatabasesController.$inject = ['$scope', '$http', '$location', '$state'];
