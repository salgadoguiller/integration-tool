var ManualIntegrationController = function ($scope, $http, $location, $state) {
    $scope.typeMessage = 0;
    $scope.message = "";
    $scope.manualIntegrations = [];
    $scope.editManualIntegration = editManualIntegration;
    $scope.executeIntegration = executeIntegration;

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
                $scope.manualIntegrations = resp;
            } else {
                $scope.message = resp.message;
                $scope.typeMessage = resp.type;
            }
        }).error(function (resp) {
            $state.transitionTo('main.errors.internalServerError');
        });
    }

    function executeIntegration(id) {
        var config = {
            headers: {
                'Content-Type': 'application/x-www-form-urlencoded;charset=utf-8;'
            }
        }

        var data = $.param({});

        $http.get('Integration/executeIntegration?id=' + id, data, config).success(function (resp) {
            $scope.message = resp.message;
            $scope.typeMessage = resp.type;
        }).error(function (resp) {
            $state.transitionTo('main.errors.internalServerError');
        });
    }

    function editManualIntegration(id) {
        $location.url('/main/integrations/configurationManual/' + id);
    }
}

ManualIntegrationController.$inject = ['$scope', '$http', '$location', '$state'];
