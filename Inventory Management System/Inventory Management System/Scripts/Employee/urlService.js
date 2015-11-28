(function () {
    'use strict';
    angular.module('IMS')
        .service('URLService', URLService);

    URLService.$inject = ['$location'];

    function URLService($location) {
        this.getArgs = getUrlArgs;
        this.setArgs = setUrlArgs;

        function getUrlArgs() {
            return $location.path().substring(1); // gets path without leading /
        }
        
        function setUrlArgs(args) {
            var newPath = args[0] !== '/'
                ? '/' + args
                : args;

            return $location.path(newPath);
        }
    }
})();