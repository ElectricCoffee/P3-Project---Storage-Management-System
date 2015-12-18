(function () {
    'use strict';
    angular.module('IMS')
        .controller('LogController', LogController);

    LogController.$inject = ['$http', 'ApiFactory'];

    function LogController($http, ApiFactory) {
        // private fields
        var self = this;
        var logService = new ApiFactory('Log'); // makes connection to /api/Log
        
        // public fields+methods
        self.getLog = getLog;
        
        function getLog() {
            logService.get().then(success, failure)

            function success(response) {
                self.tableData = response.data;
            }

            function failure(response) {
                alert(JSON.stringify(response));
            }
        }
    }
})();