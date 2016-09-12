var FormServerSMTPController = function ($scope, $http, $routeParams) {
    $scope.typeMessage = 0;
    $scope.message = "";
    $scope.request = {};
    $scope.regex = /^([0-9]*)$/;
    $scope.sendRequest = sendRequest;
    $scope.type = $routeParams.id;

    loadInfo();

    function loadInfo() {
        if ($routeParams.id == -1) {
            return;
        }

        var config = {
            headers: {
                'Content-Type': 'application/x-www-form-urlencoded;charset=utf-8;'
            }
        }

        var data = $.param({});

        $http.get('Configuration/getServerSMTP?id=' + $routeParams.id, data, config).success(function (resp) {
            if (resp.type !== 'danger') {
                $scope.request = resp;
            } else {
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

        if ($routeParams.id == -1)
            put(data, config, form);
        else
            post(data, config, form);
    }

    function put(data, config, form) {
        $http.put('Configuration/saveServerSmtp', data, config).success(function (resp) {
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

    function post(data, config, form) {
        $http.post('Configuration/updateServerSmtp', data, config).success(function (resp) {
            $scope.message = resp.message;
            $scope.typeMessage = resp.type;
            $scope.request = {};
            loadInfo();
            form.$setPristine();
            form.$setUntouched();
        }).error(function (resp) {
            $scope.message = "Error: " + resp;
            $scope.typeMessage = "danger";
        });
    }
}

FormServerSMTPController.$inject = ['$scope', '$http', '$routeParams'];

