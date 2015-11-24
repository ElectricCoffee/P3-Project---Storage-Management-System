(function () {
    'use strict';
    angular.module('IMS')
        .controller('InventoryController', InventoryController);

    InventoryController.$inject = ['EmployeeService', 'ProductService'];

    function InventoryController(EmployeeService, ProductService) {
        var self = this;
        self.productService = ProductService;
        self.addProduct = AddProduct;
        self.editProduct = EditProduct;

        self.product = {
            ArticleNumber: '',
            Name: '',
            SerialNumber: '',
            InventoryLocation: '',
            WorldLocation: '',
            Transit: '',
            InventoryStatus: '',
            Model: '',
            Category: '',
            Tags: '',
            Acquisitor: '',
            SalesStatus: '',
            Comments: ''
        };

        function AddProduct() {
            ProductService.service.post(self.product)
                .success(function (response) {
                    alert("successfully posted" + JSON.stringify(self.product));
                })
                .failure(function (response) {
                    alert("failed to post");
                })
        }
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