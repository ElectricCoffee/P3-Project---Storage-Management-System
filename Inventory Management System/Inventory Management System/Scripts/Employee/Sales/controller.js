(function () {
    'use strict';
    angular.module('IMS')
        .controller('SalesController', SalesController);

    SalesController.$inject = ['EmployeeService', 'ProductService'];

    function SalesController(EmployeeService, ProductService) {
        this.productService = ProductService;
    }
})();