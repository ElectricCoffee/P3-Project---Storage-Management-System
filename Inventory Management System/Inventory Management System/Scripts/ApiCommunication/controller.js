(function () {
    'use strict';
    angular.module('apiCommunication')
        .controller("TestController", TestController);

    TestController.$inject = ["ApiFactory"];

    function TestController(ApiFactory) {
        var self = this;
        var productFactory = new ApiFactory('Product');

        self.products = [];

        self.getData = function () {
            productFactory.read().then(function (response) {
                self.products = response.data;
            });
        };
    }
})();