(function () {
    'use strict';
    angular.module('IMS')
        .controller('TechnicianController', TechnicianController);

    TechnicianController.$inject = ['EmployeeService', 'ProductService'];

    function TechnicianController(EmployeeService, ProductService) {
        var self = this;
        self.productServices = ProductService;
        self.editProduct = editProduct;
    }
    function editProduct() {
        ProductService.service.post(self.product).success(function (response) {
            alert("successfully posted" + JSON.stringify(self.product));
        })
    }
})();