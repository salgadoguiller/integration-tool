var LoginController = function ($scope, $http) {
    $scope.typeMessage = 0;
    $scope.message = "";
    $scope.request = {};
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

        $http.post('Account/login', data, config).success(function (resp) {
            $scope.message = resp.message;
            $scope.typeMessage = resp.type;
            form.$setPristine();
            form.$setUntouched();
        }).error(function (resp) {
            $scope.message = "Error: " + resp;
            $scope.typeMessage = "danger";
        });
    }
}

LoginController.$inject = ['$scope', '$http'];