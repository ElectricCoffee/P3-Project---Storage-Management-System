(function () {
    'use strict';
    angular.module('IMS')
        .controller('ProductController', ProductController);

    ProductController.$inject = ['ApiFactory', 'URLService'];

    function ProductController(ApiFactory, URLService) {
        // private vars
        var productService = new ApiFactory('Product');
        var self = this;

        // public vars and methods
        self.addProduct     = addProduct;
        self.articleNumber  = null;
        self.deleteItem     = deleteItem;
        self.editProduct    = editProduct;
        self.getTableData   = getTableData;
        self.populateFields = populateFields;
        self.product        = null;
        self.rowArtNum      = rowArtNum;
        self.tableData      = null;

        // functions
        function addProduct() {
            productService.post(self.product).then(success, failure);

            function success() {
                alert("Successfully added");
                console.log("successfully posted" + JSON.stringify(self.product));
            }

            function failure() {
                console.error("failed to post");
            }
        }

        function deleteItem(row) {
            var articleNumber = rowArtNum(row);
            productService.delete(articleNumber).then(success, failure);

            function success() {
                console.log("successfully deleted " + articleNumber);
                getTableData(); // reload the fields
            }

            function failure() {
                alert("Could not delete " + articleNumber);
            }
        }

        function editProduct() {
            console.log("submitting form with " + JSON.stringify(self.product));
            productService.put(self.product).then(success, failure);

            function success(response) {
                alert("Product successfully editted");
                console.log("Succesfully put " + self.product);
            }
            function failure(response) {
                console.error("Failed to put" + JSON.stringify(response));
            }
        }

        function getTableData() {
            productService.get().then(success, failure);

            function success(response) {
                console.log("successfully fetched data");
                self.tableData = response.data;
            }

            function failure(response) {
                console.error("failed to fetch data");
                console.error(response.data);
            }
        }

        function populateFields() {
            var id = URLService.getArgs();
            productService.get(id).then(success, failure);

            function success(response) {
                console.log("successfully fetched data");
                self.product = response.data;
            }

            function failure(response) {
                console.error("failed to fetch data");
                console.error(response.data);
            };
        }

        function rowArtNum(row) {
            if (!self.tableData) return ''; // to keep angular from complaining
            else return self.tableData[row].ArticleNumber1;
        }
    }
})();