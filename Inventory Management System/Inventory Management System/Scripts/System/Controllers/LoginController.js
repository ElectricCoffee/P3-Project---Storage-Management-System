(function () {
    'use strict';
    angular.module('IMS')
        .controller('LoginController', LoginController);

    LoginController.$inject = ['ApiFactory'];

    function LoginController(ApiFactory) {
        var self = this;

        self.authenticate = auth;

        function auth() {
            alert(JSON.stringify(self.data));
        }
    }
})();