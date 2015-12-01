(function () {
    'use strict';
    angular.module('IMS')
        .service('FormService', FormService);

    FormService.$inject = ['URLService', 'ProductService'];

    function FormService(URLService, ProductService) {
        var self = this;

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