/// <reference path="message-directive.html" />
(function () {
    'use strict';
    angular.module('messageSystem')
        .directive('messagePopup', messageDirective);

    function messageDirective() {
        return {
            restrict: 'E',
            scope: { type: '@', sender: '@' },
            transclude: true,
            template:
                '<div class="alert alert-{{type}}">\n' +
                '  <strong>{{sender}}: </strong><span ng-transclude></span>\n' +
                '</div>'
        };
    }
})();