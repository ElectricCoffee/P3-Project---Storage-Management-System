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
        self.employeeService = EmployeeService;

        function editProduct() {
            ProductService.service.put(id, self.product).then( ///id === articlenumber
                function success(response) {
                    alert("successfully put" + JSON.stringify(self.product));
                },
                function failure(response) {
                    alert("failed to put");
                });
        }
    }
})();