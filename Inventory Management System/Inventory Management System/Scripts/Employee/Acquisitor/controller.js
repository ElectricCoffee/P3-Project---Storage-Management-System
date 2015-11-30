(function () {
    'use strict';
    angular.module('IMS')
        .controller('AcquisitorController', AcquisitorController);

    AcquisitorController.$inject = ['EmployeeService', 'ProductService', 'URLService'];

    function AcquisitorController(EmployeeService, ProductService, URLService) {
        var self = this;
        self.addProduct      = addProduct;
        self.articleNumber   = null;
        self.employeeService = EmployeeService;
        self.editProduct = function () {
            alert("submitting form with " + JSON.stringify(self.product));
            ProductService.editExistingProduct(self.product);
        };
        self.populateFields  = populateFields;
        self.productService  = ProductService;
        self.product         = null

        function addProduct() {
            alert("There should be something here: " + self.product);
            ProductService.service.post(self.product).then(success, failure);

            function success() {
                alert("successfully posted" + JSON.stringify(self.product));
            }

            function failure() {
                alert("failed to post");
            }
        }

        function populateFields() {
            var id = URLService.getArgs();
            ProductService.getProductById(id).then(success, failure);

            function success(response) {
                console.log("successfully fetched data");
                //console.log(JSON.stringify(response.data));
                self.product = response.data;
            }

            function failure(response) {
                console.error("failed to fetch data");
                console.error(response.data);
            };
        }
    }
})();