(function () {
    'use strict';
    angular.module('IMS')
        .controller('AcquisitorController', AcquisitorController);

    AcquisitorController.$inject = ['EmployeeService', 'ProductService'];

    function AcquisitorController(EmployeeService, ProductService) {
        var self = this;
        self.addProduct = addProduct;
        self.productService = ProductService;
        self.employeeService = EmployeeService;
        //self.product = {
        //    ArticleNumber1: '',
        //    Name: '',
        //    SerialNumber: '',
        //    Amount: 0,
        //    AcquisitionPrice: 0,
        //    Model: '',
        //    Category: '',
        //    Tags: '',
        //    Comments: ''
        //};

        function addProduct() {
            alert("There should be something here: " + self.product);
            ProductService.service.post(self.product).then(
                function success(response) {
                    alert("successfully posted" + JSON.stringify(self.product));
                },
                function failure(response) {
                    alert("failed to post");
                });
        }
    }
})();