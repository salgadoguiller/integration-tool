
var ConfigurationQueriesController = function ($scope, $http) {
    $scope.message = 0;
    $scope.response = "";
    $scope.request = {};
    $scope.sendRequest = sendRequest;
    $scope.queriesType = [];

    getQueriesType();

    function getQueriesType() {
        var config = {
            headers: {
                'Content-Type': 'application/x-www-form-urlencoded;charset=utf-8;'
            }
        }

        var data = $.param({});

        $http.post('Configuration/getTypeQueries', data, config).success(function (resp) {
            $scope.queriesType = resp;
        }).error(function (resp) {
            $scope.response = resp;
            $scope.message = 2;
        });
    }


    function sendRequest(req) {
        var config = {
            headers: {
                'Content-Type': 'application/x-www-form-urlencoded;charset=utf-8;'
            }
        }

        var data = $.param(req);

        $http.post('Configuration/saveQueries', data, config).success(function (resp) {
            $scope.response = resp.message;
            $scope.message = 1;
            $scope.request =
            {
                'Queries': ''
            }
        }).error(function (resp) {
            $scope.response = resp;
            $scope.message = 2;
        });
    }

}

ConfigurationQueriesController.$inject = ['$scope', '$http'];


