var ListServerSMTPController = function ($scope, $http) {
    $scope.typeMessage = 0;
    $scope.message = "";
    $scope.listServersSMTP = [];

    getListServersSMTP();

    function getListServersSMTP() {
        var config = {
            headers: {
                'Content-Type': 'application/x-www-form-urlencoded;charset=utf-8;'
            }
        }

        var data = $.param({});

        $http.post('Configuration/getListServersSMTP', data, config).success(function (resp) {
            if (resp.type !== 'danger') {
                $scope.listServersSMTP = resp;
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

ListServerSMTPController.$inject = ['$scope', '$http'];