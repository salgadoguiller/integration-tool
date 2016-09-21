var ListSystemLogsController = function ($scope, $http, $location) {
    $scope.typeMessage = 0;
    $scope.message = "";
    $scope.listSystemLogs = [];
   
    getListSystemLogs();

    function getListSystemLogs() {
        var config = {
            headers: {
                'Content-Type': 'application/x-www-form-urlencoded;charset=utf-8;'
            }
        }

        var data = $.param({});

        $http.get('Logs/getListSystemLogs', data, config).success(function (resp) {
            if (resp.type !== 'danger') {
                console.log(resp);
                $scope.listSystemLogs = resp;
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

ListSystemLogsController.$inject = ['$scope', '$http', '$location'];