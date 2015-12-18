(function () {
    'use strict';
    angular.module('IMS')
        .controller('LoginController', LoginController);

    LoginController.$inject = ['ApiFactory', "URLService"];

    function LoginController(ApiFactory, URLService) {
        // private fields
        var self = this;
        var loginService = new ApiFactory('Login');

        // public methods
        self.authenticate = function () {
            loginService.put(self.data).then(success, failure);

            function success(response) {
                if (response.data === [] || !response.data) {
                    var err =
                        "Invalid data (" +
                        JSON.stringify(response.data) +
                        ") returned from server";
                    throw new Error(err, "LoginController.js");
                }

                var url = response.data[0];
                URLService.setUrl(url);
            }

            function failure(response) {
                console.error(JSON.stringify(response));
            }
        };
    }
})();