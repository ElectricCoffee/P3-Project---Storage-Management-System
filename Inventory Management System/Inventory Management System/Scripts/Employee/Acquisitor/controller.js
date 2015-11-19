(function () {
    'use strict';
    angular.module('IMS')
        .controller('AcquisitorController', AcquisitorController);

    AcquisitorController.$inject = ['EmployeeService', 'ProductService'];

    function AcquisitorController(EmployeeService, ProductService) {
        this.productService = ProductService;
    }
})();