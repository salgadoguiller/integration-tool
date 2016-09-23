var LayoutController = function ($http, $scope, $state, Authentication) {
    $scope.sendRequest = sendRequest;

    function sendRequest() {
        var config = {
            headers: {
                'Content-Type': 'application/x-www-form-urlencoded;charset=utf-8;'
            }
        }

        var data = $.param({});

        $http.post('Account/logout', data, config).success(function (resp) {
            Authentication.user = null;
            $state.go('login');
        }).error(function (resp) {

        });
    }
}

LayoutController.$inject = ['$http', '$scope', '$state', 'Authentication'];