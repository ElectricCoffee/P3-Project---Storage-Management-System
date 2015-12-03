(function () {
    'use strict';
    angular.module('IMS')
        .directive('deleteButton', deleteButton);

    function deleteButton() {
        return {
            restrict: 'E',
            scope: { click: '&onClick' },
            transclude: true,
            template:
                '<a href="#"' + 
                   'ng-click="click()"' +
                   'class="button btn btn-danger button-gui">' +
                    '<span ng-transclude></span>' +
                '</a>'
        };
    }
})();