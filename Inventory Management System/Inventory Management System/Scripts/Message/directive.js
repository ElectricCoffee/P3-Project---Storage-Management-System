(function () {
    'use strict';
    angular.module('messageSystem')
        .directive('messagePopup', messageDirective);

    function messageDirective() {
        var messageScope = {
            alertType: '=type',
            alertTitle: '=title'
        };

        return {
            restrict: 'E', // call directive as <message-popup></message-popup>
            scope: messageScope, // enables an alert type of the form <message-popup type="success"></message-popup>
            transclude: true, // allows wrapping the tag around elements <message-popup>This is an alert</message-popup>
            templateUrl: '/message-directive.html'
        };
    }
})();