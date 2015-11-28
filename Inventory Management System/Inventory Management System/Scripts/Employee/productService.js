(function () {
    'use strict';
    angular.module('IMS')
        .service('ProductService', ProductService);

    ProductService.$inject = ['ApiFactory'];

    function ProductService(ApiFactory) {
        var productApi = new ApiFactory('Product');
        var self = this;
        self.service = productApi;
        self.tableData = [];
        self.getTableData = getTableData;
        self.addNewProduct = addNewProduct;


        function getTableData() {
            productApi.get().then(success, failure);

            function success(response) {
                console.log("successfully fetched data");
                self.tableData = response.data;
            }

            function failure(response) {
                console.error("failed to fetch data");
                console.error(response.data);
            }
        }

        function getWithId(id) {
            productApi.get(id).then(success, failure);

            function success(response) {
                console.log("successfully fetched data");
                self.tableData = response.data;
            }

            function failure(response) {
                console.error("failed to fetch data");
                console.error(response.data);
            }
        }

        function addNewProduct() {
            productApi.create(self.data)
                .success(function (response) {
                    alert("Successfully posted " + self.data);
                })
                .failure(function (response) {
                    alert("Failed to post");
                });
        }

        function editExistingProduct() {
            productApi.put(id, self.data)
                .succes(function (response) {
                    alert("Succesfully put " + self.data);
                })
                .failure(function (response) {
                    alert("Failed to put");
                });
        }
    }
})();