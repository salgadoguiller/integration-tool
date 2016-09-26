var ListUsersController = function ($scope, $http, $location, $state) {
    $scope.typeMessage = 0;
    $scope.message = "";
    $scope.listUsers = [];
    $scope.deleteUser = disableUser;
    $scope.editUser = editUser;

    getUsers();

    function getUsers() {
        var config = {
            headers: {
                'Content-Type': 'application/x-www-form-urlencoded;charset=utf-8;'
            }
        }

        var data = $.param({});

        $http.get('Users/getUsers', data, config).success(function (resp) {
            if (resp.type !== 'danger') {
                console.log(resp);
                $scope.listUsers = resp;
            } else {
                $scope.message = resp.message;
                $scope.typeMessage = resp.type;
            }
        }).error(function (resp) {
            $state.transitionTo('main.errors.internalServerError');
        });
    }

    function disableUser(UserId) {
        var config = {
            headers: {
                'Content-Type': 'application/x-www-form-urlencoded;charset=utf-8;'
            }
        }

        var data = $.param({});

        $http.delete('Configuration/disableUser?id=' + UserId, data, config).success(function (resp) {
            $scope.message = resp.message;
            $scope.typeMessage = resp.type;
            getListUsers();
        }).error(function (resp) {
            $state.transitionTo('main.errors.internalServerError');
        });
    }

    function editUser(id) {
        $location.url('/main/users/formUser/' + id);
    }
}
ListUsersController.$inject = ['$scope', '$http', '$location', '$state'];
