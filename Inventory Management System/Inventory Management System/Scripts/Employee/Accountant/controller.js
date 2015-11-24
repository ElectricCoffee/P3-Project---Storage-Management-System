(function () {
    'use strict';
    angular.module('IMS')
        .controller('AccountantController', AccountantController);

    // dependency injection
    AccountantController.$inject = ['EmployeeService', 'ProductService'];

    // controller constructor
    function AccountantController(EmployeeService, ProductService) {
        var self = this;
        self.productService = ProductService;
        self.editProduct = editProduct;

        self.product = {
            SalesStatus: ''
        };

        function EditProduct() {
            ProductService.service.put(id, self.product) ///id === articlenumber
                .success(function (response) {
                    alert("successfully put" + JSON.stringify(self.product));
                })
                .failure(function (response) {
                    alert("failed to put");
                })
        }
    }
})();