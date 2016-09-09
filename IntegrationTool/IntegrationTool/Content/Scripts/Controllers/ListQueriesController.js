var ListQueriesController = function ($scope, $http) {
    $scope.typeMessage = 0;
    $scope.message = "";
    $scope.listQueries = [];
    $scope.deleteQuery = deleteQuery;

    getlistQueries();

    function getlistQueries() {
        var config = {
            headers: {
                'Content-Type': 'application/x-www-form-urlencoded;charset=utf-8;'
            }
        }

        var data = $.param({});

        $http.get('Configuration/getlistQueries', data, config).success(function (resp) {
            if (resp.type !== 'danger') {
                $scope.listQueries = resp;
            } else {
                $scope.message = resp.message;
                $scope.typeMessage = resp.type;
            }
        }).error(function (resp) {
            $scope.message = "Error: " + resp;
            $scope.typeMessage = "danger";
        });
    }

    function deleteQuery(QueryId) {
        var config = {
            headers: {
                'Content-Type': 'application/x-www-form-urlencoded;charset=utf-8;'
            }
        }

        var data = $.param({});

        $http.delete('Configuration/deleteQuery?id=' + QueryId, data, config).success(function (resp) {
            $scope.message = resp.message;
            $scope.typeMessage = resp.type;
            getlistQueries();
        }).error(function (resp) {
            $scope.message = "Error: " + resp;
            $scope.typeMessage = "danger";
        });
    }
}
ListQueriesController.$inject = ['$scope', '$http'];