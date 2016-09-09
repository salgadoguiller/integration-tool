var ListDatabasesController = function ($scope, $http) {
    $scope.typeMessage = 0;
    $scope.message = "";
    $scope.listDatabases = [];
    $scope.deleteDatabase = deleteDatabase;

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
            $scope.message = "Error: " + resp;
            $scope.typeMessage = "danger";
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
            $scope.message = "Error: " + resp;
            $scope.typeMessage = "danger";
        });
    }
}
ListDatabasesController.$inject = ['$scope', '$http'];