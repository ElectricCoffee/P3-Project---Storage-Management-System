(function () {
    'use strict';
    angular.module('IMS')
        .controller('InventoryController', InventoryController);

    InventoryController.$inject = ['EmployeeService', 'ProductService'];

    function InventoryController(EmployeeService, ProductService) {
        var self = this;
        self.productService = ProductService;
        self.addProduct = addProduct;
        self.editProduct = editProduct;

        //self.product = {
        //    ArticleNumber: '',
        //    Name: '',
        //    SerialNumber: '',
        //    InventoryLocation: '',
        //    WorldLocation: '',
        //    Transit: '',
        //    InventoryStatus: '',
        //    Model: '',
        //    Category: '',
        //    Tags: '',
        //    Acquisitor: '',
        //    SalesStatus: '',
        //    Comments: ''
        //};

        function addProduct() {
            alert("There should be something here: " + self.product.Name);
            ProductService.service.post(self.product).then(
                function success(response) {
                    alert("successfully posted" + JSON.stringify(self.product));
                },
                function failure(response) {
                    alert("failed to post");
                });
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
    }
})();