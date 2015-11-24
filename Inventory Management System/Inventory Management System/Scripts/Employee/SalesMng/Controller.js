(function () {
    'use strict';
    angular.module('IMS')
        .controller('SalesMngController', SaleMngController);

    SalesMngController.$inject = ['EmployeeService', 'ProductService'];

    function SalesMngController(EmployeeService, ProductService) {
        this.productService = ProductService;
        this.editProduct = editProduct;
    }

    function editProduct() {
        ProductService.service.put(id, self.product) ///id === articlenumber
            .success(function (response) {
                alert("successfully put" + JSON.stringify(self.product));
            })
            .failure(function (response) {
                alert("failed to put");
            })
    }
})();