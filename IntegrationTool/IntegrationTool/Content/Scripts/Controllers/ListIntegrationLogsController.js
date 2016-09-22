var ListIntegrationLogsController = function ($scope, $http, $location) {
    $scope.typeMessage = 0;
    $scope.message = "";
    $scope.listIntegrationLogs = [];
   
    getListIntegrationLogs();

    function getListIntegrationLogs() {
        var config = {
            headers: {
                'Content-Type': 'application/x-www-form-urlencoded;charset=utf-8;'
            }
        }

        var data = $.param({});

        $http.get('Logs/getListIntegrationLogs', data, config).success(function (resp) {
            if (resp.type !== 'danger') {
                console.log(resp);
                $scope.listIntegrationLogs = resp;
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

ListIntegrationLogsController.$inject = ['$scope', '$http', '$location'];