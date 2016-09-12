var IntegrationManualController = function ($scope, $http) {
    $scope.typeMessage = 0;
    $scope.message = "";
    $scope.request = {};
    $scope.integrationsType = [];
    $scope.queries = [];
    $scope.webServices = [];
    $scope.operationsWebServices = [];
    $scope.params = [];
    $scope.databases = [];
    $scope.flatFiles = [];
    $scope.query;
    $scope.sendRequest = sendRequest;
    $scope.getQueries = getQueries;
    $scope.getQuery = getQuery; 

    getIntegrationsType();
    getWebServices();
    getOperationsWebServices();
    getDatabases();
    getFlatFiles();

    function getIntegrationsType() {
        var config = {
            headers: {
                'Content-Type': 'application/x-www-form-urlencoded;charset=utf-8;'
            }
        }

        var data = $.param({});

        $http.get('Configuration/getIntegrationsType', data, config).success(function (resp) {
            if (resp.type !== 'danger') {
                $scope.integrationsType = resp;
            } else {
                $scope.message = resp.message;
                $scope.typeMessage = resp.type;
            }
        }).error(function (resp) {
            $scope.message = "Error: " + resp;
            $scope.typeMessage = "danger";
        });
    }

    function getQueries(integrationTypeId) {
        var config = {
            headers: {
                'Content-Type': 'application/x-www-form-urlencoded;charset=utf-8;'
            }
        }

        var data = $.param({});

        $http.get('Configuration/getQueriesByIntegrationType?id=' + integrationTypeId, data, config).success(function (resp) {
            if (resp.type !== 'danger') {
                $scope.queries = resp;
                $scope.query = null;
                $scope.params = [];
            } else {
                $scope.message = resp.message;
                $scope.typeMessage = resp.type;
            }
        }).error(function (resp) {
            $scope.message = "Error: " + resp;
            $scope.typeMessage = "danger";
        });
    }

    function getWebServices() {
        var config = {
            headers: {
                'Content-Type': 'application/x-www-form-urlencoded;charset=utf-8;'
            }
        }

        var data = $.param({});

        $http.get('Configuration/getListWebServices', data, config).success(function (resp) {
            if (resp.type !== 'danger') {
                $scope.webServices = resp;
            } else {
                $scope.message = resp.message;
                $scope.typeMessage = resp.type;
            }
        }).error(function (resp) {
            $scope.message = "Error: " + resp;
            $scope.typeMessage = "danger";
        });
    }

    function getOperationsWebServices() {
        var config = {
            headers: {
                'Content-Type': 'application/x-www-form-urlencoded;charset=utf-8;'
            }
        }

        var data = $.param({});

        $http.get('Configuration/getOperationsWebServices', data, config).success(function (resp) {
            if (resp.type !== 'danger') {
                $scope.operationsWebServices = resp;
            } else {
                $scope.message = resp.message;
                $scope.typeMessage = resp.type;
            }
        }).error(function (resp) {
            $scope.message = "Error: " + resp;
            $scope.typeMessage = "danger";
        });
    }

    function getQuery(queryId) {
        var config = {
            headers: {
                'Content-Type': 'application/x-www-form-urlencoded;charset=utf-8;'
            }
        }

        var data = $.param({});

        $http.get('Configuration/getQuery?id=' + queryId, data, config).success(function (resp) {
            if (resp.type !== 'danger') {
                $scope.query = resp;
                getParams();
            } else {
                $scope.message = resp.message;
                $scope.typeMessage = resp.type;
            }
        }).error(function (resp) {
            $scope.message = "Error: " + resp;
            $scope.typeMessage = "danger";
        });
    }

    function getParams() {
        $scope.params = $scope.query.Query1.match(/\[\[.*\]\]/g);
    }

    function getDatabases() {
        var config = {
            headers: {
                'Content-Type': 'application/x-www-form-urlencoded;charset=utf-8;'
            }
        }

        var data = $.param({});

        $http.get('Configuration/getListDatabases', data, config).success(function (resp) {
            if (resp.type !== 'danger') {
                $scope.databases = resp;
            } else {
                $scope.message = resp.message;
                $scope.typeMessage = resp.type;
            }
        }).error(function (resp) {
            $scope.message = "Error: " + resp;
            $scope.typeMessage = "danger";
        });
    }

    function getFlatFiles() {
        var config = {
            headers: {
                'Content-Type': 'application/x-www-form-urlencoded;charset=utf-8;'
            }
        }

        var data = $.param({});

        $http.get('Configuration/getListFlatFiles', data, config).success(function (resp) {
            if (resp.type !== 'danger') {
                $scope.flatFiles = resp;
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
        console.log(req);
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

        $http.put('Integration/execute', data, config).success(function (resp) {
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
IntegrationManualController.$inject = ['$scope', '$http'];