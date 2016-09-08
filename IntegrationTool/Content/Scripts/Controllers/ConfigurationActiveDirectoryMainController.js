var ConfigurationActiveDirectoryMainController = function($scope, $http) {
<<<<<<< HEAD
   
    $("#example1").DataTable({
        "columnDefs": [
            { responsivePriority: 1, targets: 0 },
            { responsivePriority: 2, targets: -1 }
        ]
    });
=======
    $("#datatable")
        .DataTable({
            responsive: false
        });
>>>>>>> origin/master

}
ConfigurationActiveDirectoryMainController.$inject = ['$scope', '$http'];