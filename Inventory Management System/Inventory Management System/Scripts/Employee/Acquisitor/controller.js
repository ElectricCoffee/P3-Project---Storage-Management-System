(function () {
    'use strict';
    angular.module('IMS')
        .controller('AcquisitorController', AcquisitorController);

    AcquisitorController.$inject = ['EmployeeService', 'ProductService'];

    function AcquisitorController(EmployeeService, ProductService) {
        var self = this;
        self.productService = ProductService;
        self.addProduct = ProductService.addNewProduct;

        self.product = {
            Articlenumber: "",
            Name: "",
            SerialNumber: "",
            Model: "",
            Category: "",
            Tags: "",
            Comments: ""
        }
    }
})();