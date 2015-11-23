﻿(function () {
    'use strict';
    angular.module('IMS')
        .service('ProductService', ProductService);

    ProductService.$inject = ['ApiFactory'];

    function ProductService(ApiFactory) {
        var productApi = new ApiFactory('Product');
        var self = this;
        self.tableData = [];
        self.getTableData = getTableData;
        self.addNewProduct = addNewProduct;


        function getTableData() {
            productApi.read().then(success, failure);

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
    }
})();