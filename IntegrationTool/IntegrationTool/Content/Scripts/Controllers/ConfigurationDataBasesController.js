var ConfigurationDataBasesController = function ($scope, $http) {
    $scope.typeMessage = 0;
    $scope.message = "";
    $scope.request = {};
    $scope.regexIP = /^(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$/;
    $scope.regexPort = /^([0-9]*)$/;
    $scope.sendRequest = sendRequest;
    $scope.dataBaseEngines = [];

    getDataBaseEngines();

    function getDataBaseEngines() {
        var config = {
            headers: {
                'Content-Type': 'application/x-www-form-urlencoded;charset=utf-8;'
            }
        }

        var data = $.param({});

        $http.get('Configuration/getDataBaseEngines', data, config).success(function (resp) {
            if (resp.type !== 'danger') {
                $scope.dataBaseEngines = resp;
            }else {
                $scope.message = resp.message;
                $scope.typeMessage = resp.type;
            }
        }).error(function (resp) {
            $scope.message = "Error: " + resp;
            $scope.typeMessage = "danger";
        });
    }

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

        $http.put('Configuration/saveDataBase', data, config).success(function (resp) {
            $scope.message = resp.message;
            $scope.typeMessage = resp.type;
            $scope.request = {};
            form.$setPristine();
            form.$setUntouched();
        }).error(function (resp) {
            $scope.message = "Error: " + resp;
            $scope.typeMessage = "danger";
        });
    }
}

ConfigurationDataBasesController.$inject = ['$scope', '$http'];