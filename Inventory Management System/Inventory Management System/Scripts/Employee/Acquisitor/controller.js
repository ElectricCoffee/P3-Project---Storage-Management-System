(function () {
    'use strict';
    angular.module('IMS')
        .controller('AcquisitorController', AcquisitorController);

    AcquisitorController.$inject = ['EmployeeService', 'ProductService'];

    function AcquisitorController(EmployeeService, ProductService) {
        var self = this;
        self.productService = ProductService;
        self.addProduct = addProduct;

        self.product = {
            Articlenumber: "",
            Name: "",
            SerialNumber: "",
            Model: "",
            Category: "",
            Tags: "",
            Comments: ""
        }

        function addProduct() {
            ProductService.service.post(self.product).success(function (response) {
                alert("successfully posted" + JSON.stringify(self.product));
            });
        }
    }
})();