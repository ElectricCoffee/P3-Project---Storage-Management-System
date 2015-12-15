(function () {
    'use strict';
    angular.module('IMS')
        .controller('LoginController', LoginController);

    LoginController.$inject = ['ApiFactory', "URLService"];

    function LoginController(ApiFactory, URLService) {
        var self = this;
        var loginService = new ApiFactory('Login');

        self.authenticate = auth;

        function auth() {
            loginService.put(self.data).then(success, failure);

            function success(response) {
                if (response.data === [] || !response.data)
                    throw new Error("Invalid data (" + JSON.stringify(response.data) + ") returned from server",
                        "LoginController.js");

                var url = response.data[0];
                //var name = response.data[1];
                URLService.setUrl(url);
            }

            function failure(response) {
                alert(JSON.stringify(response));
            }
        }
    }
})();