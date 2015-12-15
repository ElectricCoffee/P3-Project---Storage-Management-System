(function () {
    'use strict';
    angular.module('IMS')
        .controller('LoginController', LoginController);

    LoginController.$inject = ['ApiFactory'];

    function LoginController(ApiFactory) {
        var self = this;
        var loginService = new ApiFactory('Login');

        self.authenticate = auth;

        function auth() {
            loginService.put(self.data).then(success, failure);

            function success(response) {
                alert(JSON.stringify(response.data));
            }

            function failure(response) {
                alert(JSON.stringify(response));
            }
        }
    }
})();