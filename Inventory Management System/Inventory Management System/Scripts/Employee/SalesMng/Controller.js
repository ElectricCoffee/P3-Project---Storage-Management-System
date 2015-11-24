(function () {
    'use strict';
    angular.module('IMS')
        .controller('SalesMngController', SalesMngController);

    SalesMngController.$inject = ['EmployeeService', 'ProductService'];

    function SalesMngController(EmployeeService, ProductService) {
        var self = this;
        self.productService = ProductService;
        self.editProduct = editProduct;

        self.product = {
            SalesStatus: '',
            SalesPrice: 0
        };

        function editProduct() {
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