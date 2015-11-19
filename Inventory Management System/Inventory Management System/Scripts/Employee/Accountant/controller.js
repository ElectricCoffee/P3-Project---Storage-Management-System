(function () {
    'use strict';
    angular.module('IMS')
        .controller('AccountantController', AccountantController);

    // dependency injection
    AccountantController.$inject = ['EmployeeService', 'ProductService'];

    // controller constructor
    function AccountantController(EmployeeService, ProductService) {
        this.productService = ProductService;
    }
})();