(function () {
    'use strict';
    angular.module('IMS')
        .controller('CreateUserController', CreateUserController);

    CreateUserController.$inject = ['$http', 'ApiFactory'];

    function CreateUserController($http, ApiFactory) {
        // private fields
        var self = this;
        var logService = new ApiFactory('User'); // makes connection to /api/Log

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