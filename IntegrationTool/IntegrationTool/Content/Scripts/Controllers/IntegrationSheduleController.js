var IntegrationSheduleController = function ($scope, $http, $location) {
    $scope.typeMessage = 0;
    $scope.message = "";
    $scope.listIntegrationShedule = [];
    $scope.integrationId = '';

    getIntegrationsShedule();
   
    function getIntegrationsShedule()
    {
        
        var config = {
            headers: {
                'Content-Type': 'application/x-www-form-urlencoded;charset=utf-8;'
            }
        }

        var data = $.param({});

        $http.get('Integration/getIntegrationsShedule', data, config).success(function (resp) {
            if (resp.type !== 'danger') {
                console.log(resp);
                // buildArray(resp);               
            }
            else {
                console.log("sfsdfas");
                console.log(resp);
                $scope.message = resp.message;
                $scope.typeMessage = resp.type;
            }
        }).error(function (resp) {
            $scope.message = "Error: " + resp;
            $scope.typeMessage = "danger";
        });
    }

    function buildArray(resp)
    {              
        for (index = 0; index < resp.length; index++)
        {
            var dateDatabase = resp[index].Calendars[0].NextExecutionDate;
            var fecha = dateDatabase.split("T");
            var fechaSplit = fecha[0].split("-");
            var horaSplit = fecha[1].split(":");

            $scope.listIntegrationShedule[index] =
            {
                id: resp[index].IntegrationId,
                title: resp[index].IntegrationsType.Name,
                start: new Date(fechaSplit[0],fechaSplit[1]-1,fechaSplit[2],horaSplit[0],horaSplit[1],horaSplit[2]),
                backgroundColor: "#f56954", //red
                borderColor: "#f56954" //red                 
            }
        }
        initScriptLoadCallendar($scope.listIntegrationShedule);
    }

    function initScriptLoadCallendar(integrationShedule) {
        /* initialize the external events
         -----------------------------------------------------------------*/
        function ini_events(ele) {
        }

        /* initialize the calendar
         -----------------------------------------------------------------*/
        $('#calendar').fullCalendar(
        {
            header:
            {
                left: 'prev,next today',
                center: 'title',
                right: 'month,agendaWeek,agendaDay,listDay'
            },
            buttonText:
            {
                today: 'today',
                month: 'month',
                week: 'week',
                day: 'day',
                list: 'list'
            },
            //Random default events
            events: integrationShedule,
            eventClick: function (event) {
                if (event.url) {
                    alert("Hola");
                    window.open(event.url);
                    return false;
                }
            }
        });
    }
}
IntegrationSheduleController.$inject = ['$scope', '$http', '$location'];