var ListHeadersController = function ($scope, $http, $location) {
    $scope.typeMessage = 0;
    $scope.message = "";
    $scope.listHeaders = [];
    $scope.deleteHeader = deleteHeader;
    $scope.editHeader = editHeader;

    getListHeaders();

    function getListHeaders() {
        var config = {
            headers: {
                'Content-Type': 'application/x-www-form-urlencoded;charset=utf-8;'
            }
        }

        var data = $.param({});

        $http.get('Configuration/getListHeaders', data, config).success(function (resp) {
            if (resp.type !== 'danger') {
                $scope.listHeaders = resp;
                console.log(resp);
            } else {
                $scope.message = resp.message;
                $scope.typeMessage = resp.type;
            }
        }).error(function (resp) {
            $scope.message = "Error: " + resp;
            $scope.typeMessage = "danger";
        });
    }

    function deleteHeader(HeaderId) {
        var config = {
            headers: {
                'Content-Type': 'application/x-www-form-urlencoded;charset=utf-8;'
            }
        }

        var data = $.param({});

        $http.delete('Configuration/deleteHeader?id=' + HeaderId, data, config).success(function (resp) {
            $scope.message = resp.message;
            $scope.typeMessage = resp.type;
            getListHeaders();
        }).error(function (resp) {
            $scope.message = "Error: " + resp;
            $scope.typeMessage = "danger";
        });
    }

    function editHeader(id) {
        $location.url('/Configuration/formHeaders/' + id);
    }
}
ListHeadersController.$inject = ['$scope', '$http', '$location'];