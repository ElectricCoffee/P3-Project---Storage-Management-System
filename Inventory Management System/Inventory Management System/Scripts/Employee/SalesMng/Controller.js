(function () {
    'use strict';
    angular.module('IMS')
        .controller('SalesMngController', SaleMngController);

    SalesMngController.$inject = ['EmployeeService', 'ProductService'];

    function SalesMngController(EmployeeService, ProductService) {
        this.productService = ProductService;
    }
})();