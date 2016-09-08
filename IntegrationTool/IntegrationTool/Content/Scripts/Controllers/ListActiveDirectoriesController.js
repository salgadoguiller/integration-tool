var ListActiveDirectoriesController = function ($scope, $http) {
    $scope.typeMessage = 0;
    $scope.message = "";
    $scope.listActiveDirectories = [];
    $scope.deleteActiveDirectory = deleteActiveDirectory;

    getListActiveDirectories();

    function getListActiveDirectories() {
        var config = {
            headers: {
                'Content-Type': 'application/x-www-form-urlencoded;charset=utf-8;'
            }
        }

        var data = $.param({});

        $http.post('Configuration/getlistActiveDirectories', data, config).success(function (resp) {
            if (resp.type !== 'danger') {
                $scope.listActiveDirectories = resp;
            } else {
                $scope.message = resp.message;
                $scope.typeMessage = resp.type;
            }
        }).error(function (resp) {
            $scope.message = "Error: " + resp;
            $scope.typeMessage = "danger";
        });
    }

    function deleteActiveDirectory(ActiveDirectoryId) {
        var config = {
            headers: {
                'Content-Type': 'application/x-www-form-urlencoded;charset=utf-8;'
            }
        }

        var data = $.param({ 'ActiveDirectoryId': ActiveDirectoryId });

        $http.post('Configuration/deleteActiveDirectory', data, config).success(function (resp) {
            $scope.message = resp.message;
            $scope.typeMessage = resp.type;
            getListActiveDirectories();
        }).error(function (resp) {
            $scope.message = "Error: " + resp;
            $scope.typeMessage = "danger";
        });
    }
}
ListActiveDirectoriesController.$inject = ['$scope', '$http'];