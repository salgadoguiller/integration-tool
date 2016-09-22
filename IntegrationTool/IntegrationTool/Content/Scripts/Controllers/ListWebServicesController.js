var ListWebServicesController = function ($scope, $http, $location) {
    $scope.typeMessage = 0;
    $scope.message = "";
    $scope.listWebServices = [];
    $scope.deleteWebService = deleteWebService;
    $scope.editWebService = editWebService;

    getListWebServices();

    function getListWebServices() {
        var config = {
            headers: {
                'Content-Type': 'application/x-www-form-urlencoded;charset=utf-8;'
            }
        }

        var data = $.param({});

        $http.get('Configuration/getListWebServices', data, config).success(function (resp) {
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

    function deleteWebService(WebServiceId) {
        var config = {
            headers: {
                'Content-Type': 'application/x-www-form-urlencoded;charset=utf-8;'
            }
        }

        var data = $.param({});

        $http.delete('Configuration/deleteWebService?id=' + WebServiceId, data, config).success(function (resp) {
            $scope.message = resp.message;
            $scope.typeMessage = resp.type;
            getListWebServices();
        }).error(function (resp) {
            $scope.message = "Error: " + resp;
            $scope.typeMessage = "danger";
        });
    }

    function editWebService(id) {
        $location.url('/main/configuration/formWebService/' + id);
    }
}
ListWebServicesController.$inject = ['$scope', '$http', '$location'];