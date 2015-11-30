﻿(function () {
    'use strict';
    angular.module('IMS')
        .service('ProductService', ProductService);

    ProductService.$inject = ['ApiFactory'];

    function ProductService(ApiFactory) {
        var productApi = new ApiFactory('Product');
        var self = this;
        self.service = productApi;
        self.tableData = null;
        self.getTableData = getTableData;
        self.addNewProduct = addNewProduct;
        self.getProductById = getWithId;
        self.editExistingProduct = editExistingProduct;


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
            return productApi.get(id)
        }

        function addNewProduct() {
            productApi.create(self.tableData)
                .success(function (response) {
                    alert("Successfully posted " + self.tableData);
                })
                .failure(function (response) {
                    alert("Failed to post");
                });
        }

        function editExistingProduct(data) {
            console.log("entering edit function");
            alert(JSON.stringify(data));
            productApi.put(data).then(success, failure);

            function success (response) {
                alert("Succesfully put " + data);
            }
            function failure(response) {
                alert("Failed to put" + JSON.stringify(response));
            }
        }
    }
})();