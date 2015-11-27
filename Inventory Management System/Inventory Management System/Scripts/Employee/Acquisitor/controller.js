(function () {
    'use strict';
    angular.module('IMS')
        .controller('AcquisitorController', AcquisitorController);

    AcquisitorController.$inject = ['EmployeeService', 'ProductService', '$route','$routeParams'];

    function AcquisitorController(EmployeeService, ProductService,$route, $routeParams) {
        var self = this;
        self.addProduct = addProduct;
        self.productService = ProductService;
        self.employeeService = EmployeeService;
        self.articlenumber = function () {
            return $route.current.params;
        }
        
        function addProduct() {
            alert("There should be something here: " + self.product);
            ProductService.service.post(self.product).then(
                function success(response) {
                    alert("successfully posted" + JSON.stringify(self.product));
                },
                function failure(response) {
                    alert("failed to post");
                });
        }
        
    }
})();