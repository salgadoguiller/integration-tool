var ListWebServicesController = function ($scope, $http) {
    $scope.typeMessage = 0;
    $scope.message = "";
    $scope.listWebServices = [];

    getListWebServices();

    function getListWebServices() {
        var config = {
            headers: {
                'Content-Type': 'application/x-www-form-urlencoded;charset=utf-8;'
            }
        }

        var data = $.param({});

        $http.post('Configuration/getListWebServices', data, config).success(function (resp) {
            if (resp.type !== 'danger') {
                $scope.listWebServices = resp;
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
ListWebServicesController.$inject = ['$scope', '$http'];