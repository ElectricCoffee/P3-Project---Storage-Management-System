(function () {
    'use strict';
    angular.module('IMS')
        .service('URLService', URLService);

    URLService.$inject = ['$location', '$window'];

    function URLService($location, $window) {
        this.getArgs = getUrlArgs;
        this.setArgs = setUrlArgs;
        this.setUrl  = setUrl;

        function getUrlArgs() {
            return $location.path().substring(1); // gets path without leading /
        }
        
        function setUrlArgs(args) {
            var newPath = mkNewPath(args);
            return $location.path(newPath);
        }

        function setUrl(aPath) {
            var newPath = mkNewPath(aPath);
            $window.location.href = newPath;
        }

        // checks if the input path starts on a /
        // if it doesn't, then / will be added
        function mkNewPath(aPath) {
            return aPath[0] !== '/'
                ? '/' + aPath
                : aPath;
        }
    }
})();