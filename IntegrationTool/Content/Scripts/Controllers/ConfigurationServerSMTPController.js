var ConfigurationServerSMTPController = function ($scope, $http){
    $scope.typeMessage = 0;
    $scope.message = "";
    $scope.request = {};
    $scope.regex = /^([0-9]*)$/;
    $scope.sendRequest = sendRequest;

    function sendRequest(req, form) {
        if (!form.$valid) {
            $scope.message = "Error: Invalid form, please try again.";
            $scope.typeMessage = "danger";
            return false;
        }

        var config = {
            headers: {
                'Content-Type': 'application/x-www-form-urlencoded;charset=utf-8;'
            }
        }

        var data = $.param(req);

        $http.post('Configuration/saveServerSmtp', data, config).success(function (resp) {
            $scope.message = "Success: " + resp.message;
            $scope.typeMessage = "success";
            $scope.request = {};
            form.$setPristine();
            form.$setUntouched();
        }).error(function (resp) {
            $scope.message = "Error: " + resp;
            $scope.typeMessage = "danger";
        });
    }

}

ConfigurationServerSMTPController.$inject = ['$scope', '$http'];

