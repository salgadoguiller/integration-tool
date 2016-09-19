var ManualIntegrationController = function ($scope, $http) {
    $scope.typeMessage = 0;
    $scope.message = "";
    $scope.manualIntegrations = [];

    getManualIntegrations();

    function getManualIntegrations() {
        var config = {
            headers: {
                'Content-Type': 'application/x-www-form-urlencoded;charset=utf-8;'
            }
        }

        var data = $.param({});

        $http.get('Integration/getManualIntegrations', data, config).success(function (resp) {
            if (resp.type !== 'danger') {
                console.log(resp);
                $scope.manualIntegrations = resp;
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

ManualIntegrationController.$inject = ['$scope', '$http'];