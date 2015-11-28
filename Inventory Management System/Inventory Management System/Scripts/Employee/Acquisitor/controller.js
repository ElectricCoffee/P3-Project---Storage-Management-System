(function () {
    'use strict';
    angular.module('IMS')
        .controller('AcquisitorController', AcquisitorController);

    AcquisitorController.$inject = ['EmployeeService', 'ProductService', 'URLService'];

    function AcquisitorController(EmployeeService, ProductService, URLService) {
        var self = this;
        self.addProduct = addProduct;
        self.articleNumber = null;
        self.employeeService = EmployeeService;
        self.populateFields = populateFields;
        self.productService = ProductService;
        self.product = null

        self.displayRoute = function () {
            alert(URLService.getArgs());
            self.articleNumber = URLService.getArgs();
        };

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
            ProductService.getWithId(id);
            alert(JSON.stringify(ProductService.tableData));
        }
    }
})();