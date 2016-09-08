var ConfigurationQueriesMainController = function ($scope, $http) {

    $("#example1")
      .DataTable({
          responsive: false
      });

    $scope.typeMessage = 0;
    $scope.message = "";
    $scope.listQueries = [];

    getlistQueries();

    function getlistQueries() {
        var config = {
            headers: {
                'Content-Type': 'application/x-www-form-urlencoded;charset=utf-8;'
            }
        }

        var data = $.param({});

        $http.post('Configuration/getlistQueries', data, config).success(function (resp) {
            if (resp.type !== 'danger') {
                $scope.listQueries = resp;
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
ConfigurationQueriesMainController.$inject = ['$scope', '$http'];