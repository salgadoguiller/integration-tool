var ConfigurationActiveDirectoryMainController = function($scope, $http) {
    $("#example1").DataTable({
        "columnDefs": [
            { responsivePriority: 1, targets: 0 },
            { responsivePriority: 2, targets: -1 }
        ]
    });
    $("#datatable")
        .DataTable({
            responsive: false
        });

}
ConfigurationActiveDirectoryMainController.$inject = ['$scope', '$http'];