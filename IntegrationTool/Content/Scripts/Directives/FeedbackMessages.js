var feedBackMessagesDirective = function () {
    return {
        restrict: 'E',
        scope: {
            type: '=',
            message: '='
        },
        template:   '<div ng-hide="type === 0" class="alert alert-{{type}} alert-dismissible col-md-10 col-md-offset-1" role="alert">' +
                        '<button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>' +
                        '<span class="fa fa-check-circle" aria-hidden="true"></span><strong></strong> {{message}}' +
                    '</div>'
    }
}