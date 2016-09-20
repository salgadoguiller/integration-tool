var IntegrationController = function ($scope, $http, $routeParams) {
    $scope.typeMessage = 0;
    $scope.message = "";
    $scope.request = {};
    $scope.integrationsType = [];
    $scope.queries = [];
    $scope.webServices = [];
    $scope.operationsWebServices = [];
    $scope.databases = [];
    $scope.flatFiles = [];
    $scope.integrationCategories = [];
    $scope.recurrences = [];
    $scope.params = [];
    $scope.query;
    $scope.database;
    $scope.sendRequest = sendRequest;
    $scope.getQueries = getQueries;
    $scope.getQuery = getQuery;
    $scope.getRecurrences = getRecurrences;
    $scope.getDatabase = getDatabase;

    getIntegrationsType();
    getWebServices();
    getOperationsWebServices();
    getDatabases();
    getFlatFiles();
    getIntegrationCategories();

    if ($routeParams.id != -1) {
        getIntegration($routeParams.id);
    }

    function integration(resp) {
        resp.IntegrationTypeId = resp.IntegrationTypeId + '';
        resp.IntegrationCategoryId = resp.IntegrationCategoryId + '';
        resp.WebServiceId = resp.WebServiceId + '';
        resp.OperationWebServiceId = resp.OperationWebServiceId + '';
        resp.DatabaseParametersId = resp.DatabaseParametersId + '';
        resp.FlatFileParameterId = resp.FlatFileParameterId + '';
        resp.QueryId = resp.QueryId + '';

        getDatabase(resp.DatabaseParametersId);
        getQueries(resp.IntegrationTypeId);
        var Interval = setInterval(function () {
            if ($scope.queries.length != 0) {
                clearInterval(Interval);
                getQuery(resp.QueryId);
            }
        }, 50);

        if (resp.IntegrationCategoryId == 2) {
            getRecurrences(resp.IntegrationCategoryId);
            resp.RecurrenceId = resp.Calendars[0].RecurrenceId + '';
            resp.Emails = resp.Calendars[0].Emails + '';
            var startDate = new Date(resp.Calendars[0].ExecutionStartDate);
            var endDate = new Date(resp.Calendars[0].ExecutionEndDate);
            startDate.setHours(startDate.getHours() + 6);
            endDate.setHours(endDate.getHours() + 6);
            resp.ExecutionStartDate = startDate;
            resp.ExecutionEndDate = endDate;
        }

        $scope.request = resp;

        for (index = 0; index < resp.QueryParameters.length; index++) {
            $scope.request[resp.QueryParameters[index].Name] = resp.QueryParameters[index].Value.replace(/\'/g, '');
        }
    }

    function getIntegration(id) {
        var config = {
            headers: {
                'Content-Type': 'application/x-www-form-urlencoded;charset=utf-8;'
            }
        }

        var data = $.param({});

        $http.get('Integration/getIntegration?id=' + id, data, config).success(function (resp) {
            if (resp.type !== 'danger') {
                integration(resp);
            } else {
                $scope.message = resp.message;
                $scope.typeMessage = resp.type;
            }
        }).error(function (resp) {
            $scope.message = "Error: " + resp;
            $scope.typeMessage = "danger";
        });
    }

    function getDatabase(id) {
        var config = {
            headers: {
                'Content-Type': 'application/x-www-form-urlencoded;charset=utf-8;'
            }
        }

        var data = $.param({});

        $http.get('Configuration/getDataBase?id=' + id, data, config).success(function (resp) {
            if (resp.type !== 'danger') {
                $scope.database = resp;
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

        console.log(req);

        var data = $.param(req);

        $http.put('Integration/saveIntegration', data, config).success(function (resp) {
            $scope.message = resp.message;
            $scope.typeMessage = resp.type;
            $scope.request = {};
            $scope.queries = [];
            $scope.recurrences = [];
            $scope.params = [];
            $scope.query = null;
            form.$setPristine();
            form.$setUntouched();
        }).error(function (resp) {
            $scope.message = "Error: " + resp;
            $scope.typeMessage = "danger";
        });
    }

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

        $http.get('Integration/getQueriesByIntegrationType?id=' + integrationTypeId, data, config).success(function (resp) {
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

        $http.get('Integration/getOperationsWebServices', data, config).success(function (resp) {
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
        params = $scope.query.Query1.match(/\[\[.*\]\]/g);
        requestParams = [];
        for (index = 0; index < params.length; index++) {
            property = 'param' + index;
            requestParams[index] = { nameParam: params[index], valueParam: '' }
        }

       
        $scope.params = requestParams;
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

    function getIntegrationCategories() {
        var config = {
            headers: {
                'Content-Type': 'application/x-www-form-urlencoded;charset=utf-8;'
            }
        }

        var data = $.param({});

        $http.get('Integration/getIntegrationCategories', data, config).success(function (resp) {
            if (resp.type !== 'danger') {
                $scope.integrationCategories = resp;
            } else {
                $scope.message = resp.message;
                $scope.typeMessage = resp.type;
            }
        }).error(function (resp) {
            $scope.message = "Error: " + resp;
            $scope.typeMessage = "danger";
        });
    }

    function getRecurrences(integrationCategory) {
        if (integrationCategory == 1) {
            $scope.recurrences = [];
            return;
        }

        var config = {
            headers: {
                'Content-Type': 'application/x-www-form-urlencoded;charset=utf-8;'
            }
        }

        var data = $.param({});

        $http.get('Integration/getRecurrences', data, config).success(function (resp) {
            if (resp.type !== 'danger') {
                $scope.recurrences = resp;
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

IntegrationController.$inject = ['$scope', '$http', '$routeParams'];