(function () {
    'use strict';
    angular.module('IMS')
        .controller('InventoryController', InventoryController);

    InventoryController.$inject = ['EmployeeService', 'ProductService', 'URLService'];

    function InventoryController(EmployeeService, ProductService, URLService) {
        var self = this;
        self.productService = ProductService;
        self.populateFields = populateFields;
        self.addProduct = addProduct;
        self.editProduct = function () {
            console.log("submitting form with " + JSON.stringify(self.product));
            ProductService.editExistingProduct(self.product);
        };
        self.employeeService = EmployeeService;

        function addProduct() {
            alert("There should be something here: " + self.product.Name);
            ProductService.service.post(self.product).then(succes, failure);
            function success(response) {
                alert("successfully posted" + JSON.stringify(self.product));
            }
            function failure(response) {
                alert("failed to post");
            }
        }
        //function editProduct() {
        //    ProductService.service.put(id, self.product) ///id === articlenumber
        //        .success(function (response) {
        //            alert("successfully put" + JSON.stringify(self.product));
        //        })
        //        .failure(function (response) {
        //            alert("failed to put");
        //        })
        //}

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