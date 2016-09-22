var ListActiveDirectoriesController = function ($scope, $http, $location) {
    $scope.typeMessage = 0;
    $scope.message = "";
    $scope.listActiveDirectories = [];
    $scope.deleteActiveDirectory = deleteActiveDirectory;
    $scope.editActiveDirectory = editActiveDirectory;

    getListActiveDirectories();

    function getListActiveDirectories() {
        var config = {
            headers: {
                'Content-Type': 'application/x-www-form-urlencoded;charset=utf-8;'
            }
        }

        var data = $.param({});

        $http.get('Configuration/getlistActiveDirectories', data, config).success(function (resp) {
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

        var data = $.param({});

        $http.delete('Configuration/deleteActiveDirectory?id=' + ActiveDirectoryId, data, config).success(function (resp) {
            $scope.message = resp.message;
            $scope.typeMessage = resp.type;
            getListActiveDirectories();
        }).error(function (resp) {
            $scope.message = "Error: " + resp;
            $scope.typeMessage = "danger";
        });
    }

    function editActiveDirectory(id) {
        $location.url('/main/configuration/formActiveDirectory/' + id);
    }
}
ListActiveDirectoriesController.$inject = ['$scope', '$http', '$location'];