﻿(function () {
    'use strict';
    angular.module('IMS')
        .controller('InventoryController', InventoryController);

    InventoryController.$inject = ['EmployeeService', 'ProductService'];

    function InventoryController(EmployeeService, ProductService) {
        this.productService = ProductService;
    }
})();