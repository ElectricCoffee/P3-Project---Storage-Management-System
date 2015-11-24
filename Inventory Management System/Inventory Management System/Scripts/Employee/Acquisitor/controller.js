(function () {
    'use strict';
    angular.module('IMS')
        .controller('AcquisitorController', AcquisitorController);

    AcquisitorController.$inject = ['EmployeeService', 'ProductService'];

    function AcquisitorController(EmployeeService, ProductService) {
        var self = this;
        self.addProduct = addProduct;
        self.productService = ProductService;

        self.product = {
            ArticleNumber: '',
            Name: '',
            SerialNumber: '',
            Amount: 0,
            AcquisitionPrice: 0,
            Model: '',
            Category: '',
            Tags: '',
            Comments: ''
        };

        function addProduct() {
            ProductService.service.post(self.product)
                .success(function (response) {
                    alert("successfully posted" + JSON.stringify(self.product));
                })
                .failure(function (response) {
                    alert("failed to post");
                })
        }
    }
})();